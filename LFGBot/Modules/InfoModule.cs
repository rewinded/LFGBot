using System;
using System.IO;
using System.Threading.Tasks;
using Discord.Commands;

namespace LFGBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private FileInfo[] _texts;
        private readonly Random _random;

        public InfoModule()
        {
            _texts = new DirectoryInfo(@"C:\Users\Rewind\Desktop\LFGDeepTexts").GetFiles();
            _random = new Random();
        }
        
        [Command("deep")]
        [Summary("Sends a message generated by the GPT-2 DeepLFG Bot")]
        public Task DeepMessage()
        {
            var text = File.ReadAllLines(_texts[_random.Next(0, _texts.Length - 1)].FullName);

            var msg = "";

            do
            {
                msg = text[_random.Next(0, text.Length - 1)];
            }
            while (msg.StartsWith("==="));

            return ReplyAsync(msg);
        }
    }
}