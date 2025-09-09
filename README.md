Here is a concise GitHub description that summarizes the gameplay, tech stack, and deliverables for the Unity Android math mini‑game.[1]

## Overview
A lightweight **Android** math challenge mini‑game where players solve randomly generated addition or subtraction equations, constrained so both questions and answers stay within 1–20.[1]
Built with Unity 2021+ (Unity 6 LTS preferred), the game uses the **New Input System**, runs in **landscape** only, and scales cleanly across 16:10 to 21:9 aspect ratios.[1]

## Features
- Mode select: Addition or Subtraction from a single menu screen.[1]
- Random linear equations with validated ranges for operands and answers (1–20).[1]
- Three lives; +1 score on correct, −1 life on wrong.[1]
- 15‑second timer per question with a ticking progress bar visualization.[1]
- Win/Lose screen with final score and buttons to restart or return to menu.[1]

## Tech
- Unity 2021+ (preferably Unity 6 LTS), Android Build Support.[1]
- Unity New Input System only; no legacy input.[1]
- Landscape orientation enforced; responsive UI between 16:10 and 21:9 via Canvas scaling and anchors.[1]
- Optional bonus: single‑scene flow (menu, gameplay, end) with a simple GameManager architecture.[1]

## How to play
Choose Addition or Subtraction, solve each equation before the 15‑second timer runs out, and aim for the highest score.[1]
Wrong answers or timeouts reduce lives, and the game ends when all lives are lost, revealing the final score with restart/menu options.[1]

## Deliverables
Public repo includes the full Unity project and a Deliverables/ folder containing the Android APK, screenshots (project folders and scene hierarchy), and a short Google Doc covering code flow, tuning, editor‑exposed parameters, and potential ScriptableObject use.[1]

[1](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/attachments/86705124/fa487437-7961-4866-9b7a-5ee0424397b3/Game-Development-Test-Math-Challenge-Mini-Game.docx)
