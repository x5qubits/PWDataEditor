using PWDataEditorPaied.Properties;
using Shield.classes.oops;
using System.IO;
using System.Media;

namespace PWDataEditorPaied.helper_classes
{
    public static class Media
    {
        public static void poweron()
        {
            if (!Constants.jas) { return; }
            Stream str = Resources.poweron;
            SoundPlayer snd = new SoundPlayer(str);
            snd.Play();
        }

        public static void welcome()
        {
            if (!Constants.jas) { return; }
            Stream str = Resources.welcome;
            SoundPlayer snd = new SoundPlayer(str);
            snd.Play();
        }

        public static void connecting()
        {
            if (!Constants.jas) { return; }
            Stream str = Resources.connecting;
            SoundPlayer snd = new SoundPlayer(str);
            snd.Play();
        }

        public static void engaging()
        {
            if (!Constants.jas) { return; }
            Stream str = Resources.engaging;
            SoundPlayer snd = new SoundPlayer(str);
            snd.Play();
        }

        public static void error()
        {
            if (!Constants.jas) { return; }
            Stream str = Resources.error;
            SoundPlayer snd = new SoundPlayer(str);
            snd.Play();
        }
    }
}
