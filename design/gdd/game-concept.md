# Game Concept: 猫咪大战 (Cat Wars)

*Created: 2026-03-26*
*Status: Draft*

---

## Elevator Pitch

> 这是一款 3 分钟一局的竖屏拾荒乱斗游戏，你将操控软萌的盲盒猫咪，在持续被染色的场景中捡起并投掷颜料瓶。每一次精准命中都能让你获得额外的弹药补给，并在不断给对手“魔性换装”的欢声笑语中争夺最多命中数。

---

## Core Identity

| Aspect | Detail |
| ---- | ---- |
| **Genre** | 休闲派对 / 乱斗躲避 |
| **Platform** | 移动端 (竖屏) |
| **Target Audience** | 女性玩家、泛休闲玩家 |
| **Player Count** | 多人对战 (初阶如 1v1 或 4人乱斗) |
| **Session Length** | 3 分钟 |
| **Monetization** | F2P (盲盒抽取外观) |
| **Estimated Scope** | Small (1个月核心独立开发MVP) |
| **Comparable Titles** | 《Splatoon》（核心涂抹视觉） / 《蛋仔派对》（物理Q弹与欢乐场面） |

---

## Core Fantasy

**随心所欲的涂鸦乱斗与解压恶搞。**
在快节奏的 3 分钟里，没有复杂的连招，只有跑位、躲避和“啪叽”砸中对手的快感。砸中不仅视觉解压，还会给对手改变外观，看着满场被砸得五颜六色、长满奇怪配饰的小猫，带来纯粹的多巴胺爆发。

---

## Unique Hook

> **打得越准，弹药越多，满场皆是换装盲盒。**
不仅能改变对手的外观，**并且（AND ALSO）**命中对手会自动补充你的弹药，鼓励玩家不断寻找机会出击，形成“高风险高收益”但门槛极低的爽快循环。

---

## Player Experience Analysis (MDA Framework)

### Target Aesthetics (What the player FEELS)
| Aesthetic | Priority | How We Deliver It |
| ---- | ---- | ---- |
| **Submission** (解压放松) | 1 | 操作极简（跑动+扔），视觉色彩丰富且充满弹性，3分钟快速结束。 |
| **Challenge** (轻竞技) | 2 | 场景道具争夺、预判走位躲避、命中后资源滚雪球。 |
| **Expression** (自我表达) | 3 | 收集并搭配盲盒猫咪，或者专门挑某个颜色砸特定对手看笑话。 |
| **Fellowship** (社交欢乐) | 4 | 互相给对方强制“穿衣变色”带来的搞怪互动。 |

### Key Dynamics (Emergent player behaviors)
*   **资源争夺抢节奏**：开局大家都会跑向场景中间或高价值颜料瓶刷新点。
*   **滚雪球与反杀**：一旦扔中对方，除了得分还能自动补给颜料，促使玩家连续攻击（“乘胜追击”）。被压制的玩家则需要利用掩体和走位去捡散落的瓶子。

### Core Mechanics (Systems we build)
1. **移动与躲避系统**：通过虚拟摇杆或拖动控制小猫移动，需要灵活走位。
2. **拾取与投掷判定**：自动或手动拾取地上的瓶子，瞄准/辅助瞄准投掷。
3. **连锁收益补充**：投掷命中有效目标后，角色携带的颜料瓶数量自动增加（+1 或 +2）。
4. **染色与外观表现**：场景和角色在被命中时渲染颜色贴图，猫咪实时增加动态配饰（如彩带、墨镜、搞怪表情）。

---

## Player Motivation Profile

### Primary Psychological Needs Served
| Need | How This Game Satisfies It | Strength |
| ---- | ---- | ---- |
| **Autonomy** (自主) | 自由跑位，选择砸谁，选择不同的猫咪出战。 | Supporting |
| **Competence** (发胜感) | 成功预判走位并连续命中对手，引发资源奖励。 | Core |
| **Relatedness** (联结) | 与朋友互坑、互砸，或者分享自己打扮出的极品“丑猫/萌猫”。 | Core |

### Player Type Appeal (Bartle Taxonomy)
*   [x] **Killers/Competitors**：命中最多者获胜，存在轻度对抗。
*   [x] **Socializers**：享受跟朋友互整的搞怪派对体验。

---

## Core Loop

### Moment-to-Moment (30 seconds)
寻找/抢夺场景中的瓶子 -> 预判走位躲避对手的攻击 -> 瞄准并投掷命中对方 -> 获取补给继续攻击。

### Short-Term (3 minutes)
以“命中最多对方”为目标，利用场景掩体，在环境逐渐被双方颜色覆盖的乱斗中，累计分数直至时间结束。

---

## Game Pillars

### Pillar 1: “命中就是一切资源”
命中对手不仅是获胜的条件，也是维持攻击节奏的唯一途径。
*Design test*: 如果在犹豫是设定“随时间缓慢恢复弹药”还是“命中奖励弹药”，一定是后者，鼓励主动出击而非龟缩。

### Pillar 2: 绝对软萌的物理反馈
所有碰撞必须是Q弹、发泄感的，不要给人疼痛或受挫的心理压力。

### Pillar 3: 色彩与外观是最高战利品
除了结束的分数结算，最让玩家记忆深刻的是那一刻满场的滑稽变色效果。

### Anti-Pillars (What This Game Is NOT)
*   **NOT 硬派射击游戏**：拒绝复杂的弹道和高门槛瞄准，采用大判定范围和辅助瞄准。
*   **NOT 零和淘汰游戏**：拒绝在3分钟内把玩家彻底淘汰导致旁观，失败只能带来分数落后，玩家始终可以在场上奔跑和捣乱。

---

## Target Player Profile
*   **Age range**: 16-35 岁
*   **Gaming experience**: 轻到中度，偏爱二次元、解压盲盒和派对类游戏。
*   **Platform preference**: 手机端（上下班碎片时间）。

---

## MVP Definition (1-Month Solo Scope)

**Core hypothesis**: “扔瓶子、看被砸的交互反馈、并在 3 分钟内因为‘命中获取资源’产生连续攻击爽感”是否足以支撑游戏循环？

**Required for MVP**:
1. 1个基础场景，3分钟倒计时机制。
2. 基础的移动和躲避操作（虚拟摇杆）。
3. 瓶子生成、拾取、大范围判定的投掷动作。
4. **核心循环**：命中对方得分并奖励弹药。
5. **视觉核心**：被命中后替换身体颜色，并随机挂载 1 个恶搞配饰（如一顶帽子或变色的脸贴图）。

**Explicitly NOT in MVP**:
*   复杂的长期收集系统/盲盒抽卡界面（后期做）。
*   多种不同地图和障碍机关。
*   复杂的多人真实网络同步（建议先做单机打笨 AI 以验证循环，不浪费1个月开发期的重点）。
