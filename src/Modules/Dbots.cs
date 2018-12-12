﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace Lykos.Modules
{

    class Dbots
    {

        public class DbotsMod : CheckBaseAttribute
        {
            public override Task<bool> CanExecute(CommandContext ctx, bool help)
            {
                if (ctx.Guild.Id == 110373943822540800)
                {
                    var ModsRole = ctx.Guild.GetRole(113379036524212224);
                    var FakeMod = ctx.Guild.GetRole(366668416058130432);
                    if (ctx.Member.Roles.Contains(ModsRole) || ctx.Member.Roles.Contains(FakeMod))
                    {
                        return Task.FromResult(true);
                    }
                    else
                    {
                        ctx.RespondAsync("<:xmark:314349398824058880> You're not a Moderator on **Discord Bots**!");
                        return Task.FromResult(false);
                    }
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
        }

        ulong BotDevID = 110375768374136832;

        [Command("undev")]
        [DbotsMod]
        [Aliases("takedev")]
        [Description("Removes Bot Developer from a user. Only usable in Discord Bots.")]
        public async Task Undev(CommandContext ctx, [Description("The user to remove a botdev role from.")] DiscordMember target, [Description("The reason for removing the role.")] params string[] reason)
        {
            String streason;
            if (reason.Length == 0)
                streason = "No reason specified.";
            else
                streason = $"[Undev by {ctx.User.Username}#{ctx.User.Discriminator}] " + String.Join(" ", reason);

            var role = ctx.Guild.GetRole(BotDevID);
            if (target.Roles.Contains(role))
            {
                await target.RevokeRoleAsync(role, streason);
                await ctx.RespondAsync($"<:check:314349398811475968> Bot Developer taken from **{target.Username}#{target.Discriminator}**!");
            } 
            else
            {
                await ctx.RespondAsync($"<:xmark:314349398824058880> **{target.Username}#{target.Discriminator}** is not a Bot Developer!");
            }

        }

        [Command("givedev")]
        [DbotsMod]
        [Description("Gives Bot Developer to a user. Only usable in Discord Bots.")]
        public async Task Givedev(CommandContext ctx, [Description("The user to give a botdev role to.")] DiscordMember target, [Description("The reason for adding the role.")] params string[] reason)
        {
            String streason;
            if (reason.Length == 0)
                streason = "No reason specified.";
            else
                streason = $"[Givedev by {ctx.User.Username}#{ctx.User.Discriminator}] " + String.Join(" ", reason);

            var role = ctx.Guild.GetRole(BotDevID);
            if (target.Roles.Contains(role))
            {
                await ctx.RespondAsync($"<:xmark:314349398824058880> **{target.Username}#{target.Discriminator}** is already a Bot Developer!");
            }
            else
            {
                await target.GrantRoleAsync(role, streason);
                await ctx.RespondAsync($"<:check:314349398811475968> Bot Developer given to **{target.Username}#{target.Discriminator}**!");
            }

        }

        public async Task Ping(CommandContext ctx)
        {
            DSharpPlus.Entities.DiscordMessage return_message = await ctx.Message.RespondAsync("Pinging...");
            ulong ping = (return_message.Id - ctx.Message.Id) >> 22;
            Char[] choices = new Char[] { 'a', 'e', 'o', 'u', 'i', 'y' };
            Char letter = choices[Program.rnd.Next(0, choices.Length)];
            await return_message.ModifyAsync($"P{letter}ng! 🏓\n" +
                $"• It took me `{ping}ms` to reply to your message!\n" +
                $"• Last Websocket Heartbeat took `{ctx.Client.Ping}ms`!");
        }

    }
}
