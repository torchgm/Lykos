﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykos.Modules
{
    class Fun : BaseCommandModule
    {
        readonly List<String> flips = new List<string>(new string[] {
            "( ﾉ⊙︵⊙）ﾉ︵┻━┻",
            "(╯°□°）╯︵┻━┻",
            "( ﾉ\\♉︵\\♉ ）ﾉ︵┻━┻",
            "┬─┬﻿ ノ( ゜-゜ノ)",
            "┬─┬﻿ ノ( °□°  ノ)"
        });

        [Command("tableflip")]
        [Description("( ﾉ⊙︵⊙）ﾉ︵┻━┻")]
        public async Task Tableflip(CommandContext ctx)
        {
            await ctx.RespondAsync(flips[Program.rnd.Next(0, flips.Count)]);
        }

        [Command("headpat")]
        [Description("Give someone a good headpat, or treat yourself to one!")]
        [Aliases("pat")]
        public async Task Headpat(CommandContext ctx, [Description("The person to give a headpat to!"), RemainingText] string target = "me")
        {
            target = Helpers.sanitiseEveryone(target);

            if (target == null || target == "me" || target == ctx.User.Username || target == ctx.Member.Nickname || target == ctx.Member.Mention)
            {
                await ctx.RespondAsync($"{Program.cfgjson.Emoji.BlobPats} \\*gives a big headpat to {ctx.User.Mention}\\*");
            }
            else
            {
                await ctx.RespondAsync($"{Program.cfgjson.Emoji.BlobPats} {target} was given a big headpat by {ctx.User.Username}!");
            }
        }

        [Command("hug")]
        [Description("Give someone a good headpat, or treat yourself to one!")]
        public async Task Hug(CommandContext ctx, [Description("The person to give a headpat to!"), RemainingText] string target = "me")
        {
            target = Helpers.sanitiseEveryone(target);

            if (target == null || target == "me" || target == ctx.User.Username || target == ctx.Member.Nickname || target == ctx.Member.Mention)
            {
                await ctx.RespondAsync($"{Program.cfgjson.Emoji.BlobHug} \\*gives a tight hug to {ctx.User.Mention}\\*");
            }
            else
            {
                await ctx.RespondAsync($"{Program.cfgjson.Emoji.BlobHug} {target} was given a tight hug by {ctx.User.Username}!");
            }
        }

        [Command("pingeri")]
        [Description("Pong!")]
        public async Task Pingeri(CommandContext ctx)
        {
            await ctx.RespondAsync("<@228574821590499329>");
        }

        [Command("whenissarahsbirthday")]
        public async Task Whenissarahsbirthday(CommandContext ctx)
        {
            await ctx.RespondAsync($"Today.");
        }

        [Command("cotd")]
        public async Task Cotd(CommandContext ctx)
        {
            var scat = await ctx.Client.GetUserAsync(103347843934212096);
            await ctx.RespondAsync($"Todays cat of the day is **{scat.Username}#{scat.Discriminator}**!");
        }

        [Command("gotd")]
        public async Task Gotd(CommandContext ctx)
        {
            var circ = await ctx.Client.GetUserAsync(255114091360681986);
            await ctx.RespondAsync($"Todays genius of the day is **{circ.Username}#{circ.Discriminator}**!");
        }

        [Command("zotd")]
        public async Task zotd(CommandContext ctx)
        {
            var zeta = await ctx.Client.GetUserAsync(94129005791281152);
            await ctx.RespondAsync($"Todays Zeta of the day is **{zeta.Username}#{zeta.Discriminator}**!");
        }

        [Command("coty")]
        public async Task Zotd(CommandContext ctx)
        {
            var cutie = await ctx.Client.GetUserAsync(155659573515124736);
            await ctx.RespondAsync($"The cute of the year is **{cutie.Username}#{cutie.Discriminator}**!");
        }

    }
}
