# Play Studios Technical Challenge
Technical Challenge for Play Studios Asia

## The Chanllenge
To create a simple, compelling and self-contained picker game. 
The game shoud present players with a variety of choices.
The game should have at least the following four phases
- Intro/beginning
- Game play
- Summary of win
- Outro/end/ prompt to play again

## Design Decision
Picker games are usually heavily luck dependent due to the RNG. The output randomness makes players' actions generally have unpredictable results.

One of the biggest focus in designing the game is to implement something that let players gain some control to the outcome. Hence, a tier system for the prizes. It narrows randomness and allow more player agency to decide what kind of randomness do they want to be exposed to.

Another focus is the resource management. Players will use more tokens to unlock high tiers. But they will be exposed to riskier "prizes". And since they can't undo their decision once a slot is selected, it offers another layers to the picking strategy. Players can some strategies on how to spend the tokens are the most efficient.

I deliberately design the tiers offer different prizes so every tier has their values. Players are guaranteed to get a decent but small amount of prizes in tier 1. I specifically add token refunds on tier 2 to encourage players to risk unlocking tier 3 prizes. Tier 3 mainly consist of positive and negative multiplier to player's point within a single round. This means only going for tier 3 is not totally the best option.

## Game Objective
- Players are provided with a number of tokens when they start a round (7 currently). 
- Players use tokens to unlock some of the 12 bubble slots.
- Bubble slots have pre-generated prize. They also have multiple tier prizes (3 in total).
- Players can use multiple tokens to unlock higher tier prizes.
- The higher the tier, the bigger the reward and the risk.
- Round ends when all tokens are spended.

## Game Features
3 Tiers of prizes
1. Low reward prizes, no risks.
    Point prize (100 - 250) (High%) | 1 token refund (Low%)
2. Better reward prizes, slight risks, prepare players to try Tier 3
    Point prize (500 / 750 / 10 / 20) (Mid%) | 1 / 3 tokens refund (Mid%)
3. Best reward prizes, but also risk lost all prizes
    Point multiplier (1.5x / 4x) | Point deductor (0.75x / 0x) | 1 token refund (Low%)

## Mechanics Features
- Scriptable objects are used to store most datas such as player's statistics, current states, loot table, generated patterns, etc.
- Scriptable objects are also used to communicate between scripts.
- Delegates are 2nd most used communicative device.
- Inputs are handled through Event Trigger in Editor.