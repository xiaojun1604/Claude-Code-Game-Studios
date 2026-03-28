# Systems Index: 猫咪大战 (Cat Wars)

> **Status**: Approved
> **Created**: 2026-03-26
> **Last Updated**: 2026-03-26
> **Source Concept**: design/gdd/game-concept.md

---

## Overview

《猫咪大战》是一个 3 分钟极验的休闲竖屏派对游戏。由于核心玩法是高频的“跑位-拾取-投掷染色”，游戏极度依赖稳固的底层资源调度（配置表与对象池）来确保多特效同屏不卡顿。在此之上，基础的控制、物理碰撞、以及染色换装系统构成了整个游戏的心流循环框架。

---

## Systems Enumeration

| # | System Name | Category | Priority | Status | Design Doc | Depends On |
|---|-------------|----------|----------|--------|------------|------------|
| 1 | Input System (输入系统) | Core | MVP | Not Started | — | None |
| 2 | Config Data System (表格配置系统) | Core | MVP | Not Started | — | None |
| 3 | Resource Management (资源加载系统) | Core | MVP | Not Started | — | None |
| 4 | Spawn & Pool System (生成与对象池) | Core | MVP | Not Started | — | Resource Management |
| 5 | Match Flow System (对局流程系统) | Gameplay | MVP | Not Started | — | Config Data |
| 6 | Character Controller (角色控制器) | Gameplay | MVP | Not Started | — | Input System |
| 7 | Weapon & Hit System (投掷与判定) | Gameplay | MVP | Not Started | — | Pool System, Config Data |
| 8 | Ammo Management (弹药管理系统) | Economy | MVP | Not Started | — | Hit System |
| 9 | Dye & Dress-up System (染色变装) | Gameplay | MVP | Not Started | — | Hit System, Resource Management |
| 10| Battle UI (战斗UI) | UI | MVP | Not Started | — | Match Flow, Ammo Management |
| 11| Feedback System (反馈特效) | Audio/Visual | MVP | Not Started | — | Hit System, Object Pool |

---

## Dependency Map

### Foundation Layer (no dependencies)
1. **Input System** — 所有交互操作的基础
2. **Config Data System (Excel)** — 提供游戏参数（武器伤害、弹药上限、时间）
3. **Resource Management System** — 负责加载模型、特效、UI 预制体 (如 Addressables)

### Core Layer (depends on foundation)
4. **Spawn & Pool System** — 依赖: Resource Management
5. **Character Controller** — 依赖: Input System
6. **Match Flow System** — 依赖: Config Data System

### Feature Layer (depends on core)
7. **Weapon & Hit System** — 依赖: Spawn & Pool System, Config Data System (读取投掷参数)
8. **Ammo Management** — 依赖: Weapon & Hit System (通过命中获取收益)
9. **Dye & Dress-up System** — 依赖: Weapon & Hit System (被命中触发), Resource Management (加载配饰)

### Presentation Layer (depends on features)
10. **Battle UI** — 依赖: Match Flow System (倒计时), Ammo Management (弹丸数量)
11. **Feedback System** — 依赖: Weapon & Hit System (触发时机), Spawn & Pool System (特效生成)

---

## Recommended Design Order

| Order | System | Priority | Layer | Agent |
|-------|--------|----------|-------|-------|
| 1 | Config Data System (表格配置) | MVP | Foundation | lead-programmer |
| 2 | Resource Management (资源加载) | MVP | Foundation | lead-programmer |
| 3 | Input System | MVP | Foundation | gameplay-programmer |
| 4 | Spawn & Pool System | MVP | Core | engine-programmer |
| 5 | Character Controller | MVP | Core | gameplay-programmer |
| 6 | Match Flow System | MVP | Core | systems-designer |
| 7 | Weapon & Hit System | MVP | Feature | gameplay-programmer |
| 8 | Ammo Management | MVP | Feature | systems-designer |
| 9 | Dye & Dress-up System | MVP | Feature | technical-artist |
| 10| Battle UI | MVP | Presentation | ui-programmer |
| 11| Feedback System | MVP | Presentation | technical-artist |

---

## High-Risk Systems

| System | Risk Type | Risk Description | Mitigation |
|--------|-----------|-----------------|------------|
| **Dye & Dress-up System** | Technical | 移动端同时产生大量动态换装和材质替换可能造成严重的 DrawCall 飙升。 | 使用统一的色相偏移 Shader 替代材质替换，换装限制最大挂点数量。 |
| **Weapon & Hit System** | Technical | Unity 原生的 OnCollisionEnter 在抛体高速运动时极易穿模，带来糟糕体验。 | 原型期已发现该问题，正式版重写基于 SphereCast/Raycast 的前向判定。 |

---

## Progress Tracker

| Metric | Count |
|--------|-------|
| Total systems identified | 11 |
| Design docs started | 0 |
| Design docs approved | 0 |
| MVP systems designed | 0/11 |
