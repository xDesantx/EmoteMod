﻿using Monocle;

namespace Celeste.Mod.EmoteMod
{
    public class BackpackModule
    {
        public static Player player;
        internal static void Player_ResetSprite(On.Celeste.Player.orig_Update orig, Player self)
        {
            orig(self);
            // so that it doent mess with emotes
            if (Engine.Scene is Level && EmoteModMain.anim_by_game == 0)

                // force backpack
                if (EmoteModMain.Settings.Backpack == 1 && self.Sprite.Mode != PlayerSpriteMode.Madeline)
                    self.ResetSprite(PlayerSpriteMode.Madeline);
                // force no backpack
                else if (EmoteModMain.Settings.Backpack == 2 && self.Sprite.Mode != PlayerSpriteMode.MadelineNoBackpack)
                    self.ResetSprite(PlayerSpriteMode.MadelineNoBackpack);
                // playback sprite mode
                else if (EmoteModMain.Settings.Backpack == 3 && self.Sprite.Mode != PlayerSpriteMode.Playback)
                    self.ResetSprite(PlayerSpriteMode.Playback);
                // else apply either default skin
                else if (EmoteModMain.Settings.Backpack == 0 && !SaveData.Instance.Assists.PlayAsBadeline && self.Sprite.Mode != self.DefaultSpriteMode) // default
                    self.ResetSprite(self.DefaultSpriteMode);
                // or badeline
                else if (EmoteModMain.Settings.Backpack == 0 && SaveData.Instance.Assists.PlayAsBadeline && self.Sprite.Mode != PlayerSpriteMode.MadelineAsBadeline) // default
                    self.ResetSprite(PlayerSpriteMode.MadelineAsBadeline);

            player = self;

        }
    }
}