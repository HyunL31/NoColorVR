# 🎮 No Color Land Part.2 – VR Horror Puzzle Game

**Immersive Media Programming – Final VR Project (Team 3)**  
A VR horror game set in the mysterious world of *No Color Land*. Explore, solve puzzles, and survive in a cave haunted by unknown monster.

---

## 🧭 Concept Overview

- **Title:** *No Color Land Part.2*
- **Genre:** Horror + Puzzle
- **Platform:** VR (Meta Quest)
- **Core Idea:** Navigate a dark cave, solve puzzles, and fight with a monster using a magical oil lamp.

---

## 🌌 Story

A young boy enters a mysterious cave inside *No Color Land*.  
Inside, he finds clues and keys that may help him escape and reveal the truth behind the land’s lost light.

- **Level 1:** Puzzle Phase – Solve four puzzles and collect scrolls and keys.
- **Level 2:** Monster Phase – Escape from the Mimic while using a color lamp as your only weapon.

---

## 🧱 System Architecture

| Script              | Description |
|---------------------|-------------|
| **GameManager.cs**  | Manages overall game flow (Start → Level1 → Level2 → Ending), player respawn, and monster activation. |
| **LevelChanger.cs** | Detects level completion zones and changes scenes. |
| **CharacterManager.cs** | Manages health, damage, inventory (keys and scrolls), and death transitions (Singleton). |
| **InventoryUI.cs**  | Handles item display, scroll reading, and key spawning in VR. |
| **Movement.cs**     | Controls Mimic AI with NavMeshAgent, applying effects like stun/slow. |
| **ColorController.cs** | Controls color selection and lamp interaction during Level 2. |
| **Puzzle Scripts**  | ButtonPuzzle.cs, LightPuzzle.cs, FinalPuzzleController.cs – Implement environmental puzzles with lights, movement, and clues. |

---

## 🎮 Gameplay Instructions

### 📌 Title / Menu Scene
- Press **START** to begin.
- Pause anytime with **Left Primary Button** to access menu options.
- Click **Home** to return to the title screen and reset progress.

### 🔦 Level 1 – Puzzle Phase
- Use the **lamp** to light stone lamps and find clues.

#### 🧩 4 Puzzle Types
1. **Light Button Puzzle** – Press buttons in the correct order.
2. **Moving Plate Puzzle** – Cross moving platforms with timed moving.
3. **Stone Lamp Puzzle** – Light lamps to raise platforms and reach new clue.
4. **Mimic Lamp Puzzle** – Light the lamps where the Mimic is present.

- Place items into the **lamp socket** to store them.
- Press **Right Secondary Button** to open scroll inventory.
- After collecting all items, insert the lamp into the **socket table** to raise the ground and complete Level 1.

### 👹 Level 2 – Monster Phase
- Press **Right Primary Button** to open the **Color Selector**.
- Change the lamp's flame and pull out **Color Balls** as weapons.
- Throw them at the Mimic to apply effects (stun, freeze, etc).
- If the Mimic touches you 3 times, the screen will vignette with blood and you’ll die.
- To escape, find the **climbing point** and reach the top.

---

## 📁 Assets Used

- [Lamp / Gem Prop](https://assetstore.unity.com/packages/3d/props/props-3d-221035)  
- [Color Ball (VFX)](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/procedural-fire-141496)  
- [Scroll](https://skfb.ly/6XtPo)  
- [Mimic Monster](https://assetstore.unity.com/packages/3d/characters/creatures/mimic-prototype-245997)  
- [Cave Map Assets](https://assetstore.unity.com/packages/3d/environments/mines-and-cave-set-305701)  
- [Realtime CSG Tool](https://assetstore.unity.com/packages/tools/modeling/realtime-csg-69542)  
- [Blood/Frame/Scroll UI](https://pngtree.com)  
- [Font](https://noonnu.cc/font_page/1173)  
- [Table Prop](https://sketchfab.com/3d-models/old-table-c1391f05e2a046ef9bd91945caf75fb8)  
- [BGM – Horror Ambient Sounds](https://assetstore.unity.com/packages/audio/ambient/horror-ambient-sounds-pack)  
- [SFX – Pixabay](https://pixabay.com/sound-effects/)  
- [Puzzle Ground SFX](https://gongu.copyright.or.kr/gongu/wrt/wrt/view.do?wrtSn=13253189&menuNo=200020)  
- [Stone Lamp SFX](https://assetstore.unity.com/packages/audio/sound-fx/free-fireworks-fire-fx-nova-sound-39475)  
- [Inventory Icon Source](https://www.flaticon.com/)

---

## 🤖 AI Tool Usage

- Generated a **fan-shaped UI image** divided into four parts for the Color Selector.
- Translated scroll clues and adapted them into a **fantasy-style tone** for immersive storytelling.
