using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd2
{
    struct Song
    {
        public string Author;
        public string Title;
        public string Filename;
        public Song(string author, string title, string fileName) // конструктор для структуры Song
        {
            Author = author;
            Title = title;
            Filename = fileName;
        }
    }
    class Playlist
    {
        private List<Song> list;
        private int currentIndex;

        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }
        public Song CurrentSong() // получение текущей аудиозаписи
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }
        public List<Song> AllSongs() // получение списка со всеми песнями
        {
            return new List<Song>(list);
        }
        public void AddSong(string author, string title, string fileName) // добавление песни по параметрам
        {
            Song song = new Song(author, title, fileName);
            if (!list.Contains(song))
            {
                list.Add(song);
                MessageBox.Show("Песня добавлена успешно");
            }
            else
            {
                MessageBox.Show("Такая песня уже есть");
            }
            
        }
        public void AddSong(Song song) // добавление песни
        {
            if (!list.Contains(song))
            {
                list.Add(song);
                MessageBox.Show("Песня добавлена успешно");
            }
            else
            {
                MessageBox.Show("Такая песня уже есть");
            }
        }
        public void RemoveSong(int index) // удаление песни по индексу
        {
            list.RemoveAt(index);
        }
        public void RemoveSong(Song song) // удаление песни по значению типа Song
        {
            if (list.Remove(song))
            {
                if (currentIndex >= list.Count)
                {
                    currentIndex = list.Count - 1;
                }
            }
        }
        public void ClearList() // очистка списка с песнями
        {
            list.Clear();
            currentIndex = 0;
        }
        
    }
}
