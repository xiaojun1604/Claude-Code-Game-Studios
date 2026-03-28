## Prototype Report: Cat Wars Core Loop

### Hypothesis
“扔瓶子、看被砸的交互反馈、并在 3 分钟内因为‘命中获取资源’产生连续攻击爽感”足以在没有复杂射击机制下支撑起有趣的核心游戏循环。命中补充弹药的设计能促使玩家保持主动进攻。

### Approach
建立了两段独立的抛弃型测试脚本 (`PlayerController.cs` 和 `DyeBottle.cs`)，用最粗暴的 `Instantiate` 和 Unity 原生物理碰撞 (`OnCollisionEnter`) 实现了基础投掷和命中检测。

### Result
待在 Unity Editor 中放入白盒测试。
预期效果：只要玩家命中目标的概率超过特定阈值（例如 50%），手中的弹药就会越打越多，产生正向反馈；如果打偏，则必须去场景中重新“拾荒”，形成战术间歇。

### Metrics
- Frame time: N/A（目前为极简物理验证，无评估必要）
- Feel assessment: 期待打中时系统奖励弹药的“叮”声加上视觉反馈，能在手感上提供足够的爽快度。
- Player action counts: 预估单局 3 分钟内，玩家平均有效投掷在 30-50 次左右。

### Recommendation: PROCEED (Pending Editor Playtest)
该核心循环逻辑能够自洽，高频的正向资源反馈非常适合短时派对游戏。

### If Proceeding
如果该原型在 Unity 编辑器里测试好玩，接下来的生产级代码必须做出以下调整：
- 原型大量使用了 `GameObject.Instantiate`，生产环境必须切换为 **Object Pool (对象池)** 或采用 Addressables 异步实例化以保证移动端性能。
- 原型中的 `OnCollisionEnter` 物理开销较大且对高速抛射物容易出现穿模 (Tunneling)，生产环境建议重写为基于 `SphereCast` 的抛物线预测检测。
- 逻辑与表现需要解耦，不能直接修改 `Renderer.material.color`。

### Lessons Learned
在资源获取维度，必须加入对当前弹药数量的“软上限”控制（比如身上最多只能存 5 个瓶子）。否则遇到神射手玩家，可能会出现无休止投掷的火力压制，导致被动方毫无还手之力（在实际 Playtest 中需重点观察）。
