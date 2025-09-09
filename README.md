## Overview
A lightweight **Android** math challenge mini‑game where players solve randomly generated addition or subtraction equations, constrained so both questions and answers stay within 1–20.
Built with Unity 2021+ (Unity 6 LTS preferred), the game uses the **New Input System**, runs in **landscape** only, and scales cleanly across 16:10 to 21:9 aspect ratios.

## Features
- Mode select: Addition or Subtraction from a single menu screen.
- Random linear equations with validated ranges for operands and answers (1–20).
- Three lives; +1 score on correct, −1 life on wrong.
- 15‑second timer per question with a ticking progress bar visualization.
- Win/Lose screen with final score and buttons to restart or return to menu.

## Tech
- Unity 2021+ (preferably Unity 6 LTS), Android Build Support.
- Unity New Input System only; no legacy input.
- Landscape orientation enforced; responsive UI between 16:10 and 21:9 via Canvas scaling and anchors.
- Optional bonus: single‑scene flow (menu, gameplay, end) with a simple GameManager architecture.

## How to play
Choose Addition or Subtraction, solve each equation before the 15‑second timer runs out, and aim for the highest score.
Wrong answers or timeouts reduce lives, and the game ends when all lives are lost, revealing the final score with restart/menu options.

## Deliverables
Public repo includes the full Unity project and a Deliverables/ folder containing the Android APK, screenshots (project folders and scene hierarchy), and a short Google Doc covering code flow, tuning, editor‑exposed parameters, and potential ScriptableObject use.

(https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/attachments/86705124/fa487437-7961-4866-9b7a-5ee0424397b3/Game-Development-Test-Math-Challenge-Mini-Game.docx)
