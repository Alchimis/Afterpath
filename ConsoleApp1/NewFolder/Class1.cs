using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace ConsoleApp1.NewFolder
{

    // Музыкальный плейер(ну типа)
    internal class Player
    {
        // типа плейлист
        private List<string> _musicList;
        // типа состояние плейера
        private PlayerStatus _status;
        // типа то что сейчас играет
        private int _musicPlayed;
        private Task? _task;
        private CharEnumerator? _ch;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;
        public CharEnumerator? Ch { get { return _ch; } }
        public int MusicPlayedIndex { get { return _musicPlayed; } set { _musicPlayed = value; } }
        public string MusicPlayed { get { return _musicList[_musicPlayed]; } }
        public PlayerStatus Status { get { return _status; } }
        public List<string> MusicList { get { return _musicList; } }
        // конструктор
        public Player(List<string> musicList)
        {
            _musicList = musicList;
            _status = PlayerStatus.new_music;
            _musicPlayed = 0;
            _ch = _musicList[_musicPlayed].GetEnumerator();

            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _task = new Task(MusicPlay, _token);
            //_task.Start();

        }
        /* private void Loop() {
             while (true)
             {
                 if (_status != PlayerStatus.play) { continue; }

                 if (_ch.MoveNext())
                 {
                     Console.Write(_ch.Current);
                 }
                 else
                 {
                     _status = PlayerStatus.new_music;

                 }
                 //Thread.Sleep(1000);
             }
         }*/
        public void MusicPlay()
        {

            while (_ch.MoveNext())
            {

                Console.Write(_ch.Current);

                Thread.Sleep(1000);
                if (_token.IsCancellationRequested) { return; }
            }
            _status = PlayerStatus.new_music;
        }
        // переключить на следующую музыку
        public void Next()
        {
            if (_musicPlayed >= _musicList.Count - 1)
            {
                _musicPlayed = 0;
            }
            else
            {
                _musicPlayed++;
            }
            if (_status != PlayerStatus.pause) { Stop(); }

            _status = PlayerStatus.new_music;
        }

        // переключить на предыдущую музыку
        public void Previous()
        {
            if (_musicPlayed <= 0)
            {
                _musicPlayed = _musicList.Count - 1;
            }
            else
            {
                _musicPlayed--;
            }
            if (_status != PlayerStatus.pause) { Stop(); }
            _status = PlayerStatus.new_music;
        }
        // запустить проигрыш
        public void Play()
        {
            //Console.WriteLine("play");
            if (_status == PlayerStatus.new_music)
            {
                _ch = _musicList[_musicPlayed].GetEnumerator();
            }
            _status = PlayerStatus.play;
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _task = new Task(() => { MusicPlay(); }, _token);// mp
            _task.Start();
        }
        // остановить проигрыш
        public void Stop()
        {
            // Console.WriteLine("stop");
            _status = PlayerStatus.pause;
            //

            //_task!.Dispose();
            if (!_tokenSource.IsCancellationRequested)
            {
                _tokenSource.Cancel();
                _tokenSource.Dispose();
            }
        }
    }
    enum PlayerStatus
    {
        play,
        pause,
        new_music,
    }
}






















/// плейер
/*namespace ConsoleApp1.NewFolder
{
    
    // Музыкальный плейер(ну типа)
    internal class Player
    {
        // типа плейлист
        private List<string> _musicList;
        // типа состояние плейера
        private PlayerStatus _status;
        // типа то что сейчас играет
        private int _musicPlayed;
        private Task _task { get; set; }
        public int MusicPlayedIndex { get { return _musicPlayed; } set { _musicPlayed = value; } }
        public string MusicPlayed { get { return _musicList[_musicPlayed]; } }
        public PlayerStatus Status { get { return _status; } }
        private List<string> MusicList { get { return _musicList; } }
        // конструктор
        public Player(List<string> musicList) { 
            _musicList = musicList;
            _status = PlayerStatus.pause;
            _musicPlayed = 0; 
            _task = new Task(() => {
                var ch = _musicList[_musicPlayed].GetEnumerator();
                while (true)
                {
                    if (_status == PlayerStatus.new_music) { 
                        ch = _musicList[_musicPlayed].GetEnumerator(); 
                        Console.WriteLine(_musicPlayed);
                        _status = PlayerStatus.pause;
                    }
                    if (_status != PlayerStatus.play) { continue; }
                    
                    if (ch.MoveNext())
                    {
                        Console.Write(ch.Current);
                    }
                    else
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
            });
            _task.Start();

        }

        
        // переключить на следующую музыку
        public void Next() {
            if (_musicPlayed >= _musicList.Count-1)
            {
                _musicPlayed = 0;
            }
            else {
                _musicPlayed++;
            }
            _status = PlayerStatus.new_music;
        }
        /// переключить на предыдущую музыку
        public void Previous() {
            if (_musicPlayed <= 0)
            {
                _musicPlayed = _musicList.Count - 1;
            }
            else 
            {
                _musicPlayed--;
            }
            _status = PlayerStatus.new_music;
        }
        // запустить проигрыш
        public void Play()  {
           _status = PlayerStatus.play;
        }
        // остановить проигрыш
        public void Stop() {
            _status = PlayerStatus.pause; 
        }


    }
    // состояние проигрывателя
    enum PlayerStatus {
        play,
        pause,
        new_music,
    }
}
*/
// музыка - строки
/*namespace ConsoleApp1.NewFolder
{

    // Музыкальный плейер(ну типа)
    internal class Player
    {
        // типа плейлист
        private List<string> _musicList;
        // типа состояние плейера
        private PlayerStatus _status;
        // типа то что сейчас играет
        private int _musicPlayed;
        private Task? _task;
        private CharEnumerator? _ch;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;
        public CharEnumerator? Ch { get { return _ch; } }
        public int MusicPlayedIndex { get { return _musicPlayed; } set { _musicPlayed = value; } }
        public string MusicPlayed { get { return _musicList[_musicPlayed]; } }
        public PlayerStatus Status { get { return _status; } }
        public List<string> MusicList { get { return _musicList; } }
        // конструктор
        public Player(List<string> musicList)
        {
            _musicList = musicList;
            _status = PlayerStatus.new_music;
            _musicPlayed = 0;
            _ch = _musicList[_musicPlayed].GetEnumerator();
            
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _task = new Task(MusicPlay,_token);
            //_task.Start();

        }
        *//* private void Loop() {
             while (true)
             {
                 if (_status != PlayerStatus.play) { continue; }

                 if (_ch.MoveNext())
                 {
                     Console.Write(_ch.Current);
                 }
                 else
                 {
                     _status = PlayerStatus.new_music;

                 }
                 //Thread.Sleep(1000);
             }
         }*//*
        private void MusicPlay()
        {

            while (_ch.MoveNext())
            {
                
                Console.Write(_ch.Current);
                Thread.Sleep(1000);
                if (_token.IsCancellationRequested) { return; }
            }
            _status = PlayerStatus.new_music;
        }
        public static Action MusicPlayConstruct(CharEnumerator? ch, PlayerStatus status)
        {
            return () =>
            {
                while (ch.MoveNext())
                {
                    Console.Write(ch.Current);
                    Thread.Sleep(1000);
                }
                status = PlayerStatus.new_music;
            };
        }
        // переключить на следующую музыку
        public void Next()
        {
            if (_musicPlayed >= _musicList.Count - 1)
            {
                _musicPlayed = 0;
            }
            else
            {
                _musicPlayed++;
            }
            Stop();
            _status = PlayerStatus.new_music;
        }

        // переключить на предыдущую музыку
        public void Previous()
        {
            if (_musicPlayed <= 0)
            {
                _musicPlayed = _musicList.Count - 1;
            }
            else
            {
                _musicPlayed--;
            }
            _status = PlayerStatus.new_music;
            Stop();
        }
        // запустить проигрыш
        public void Play()
        {
            Console.WriteLine("play");
            if (_status == PlayerStatus.new_music)
            {
                _ch = _musicList[_musicPlayed].GetEnumerator();
            }
            _status = PlayerStatus.play;
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _task = new Task(()=> { MusicPlay(); },_token);// mp
            _task.Start();
        }
        // остановить проигрыш
        public void Stop()
        {
            Console.WriteLine("stop");
            _status = PlayerStatus.pause;
            //

            //_task!.Dispose();
            _tokenSource.Cancel();
            _tokenSource.Dispose();
        }
    }
    enum PlayerStatus
    {
        play,
        pause,
        new_music,
    }
}
*/
// музыка - строки



