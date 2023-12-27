using System;

namespace Aviasales
{
    public class Airport : IComparable<Airport>, IEquatable<Airport> // Класс Аэропорт, интерфейсы
    {
        private Guid id; // Уникальный идентификатор аэропорта
        private string name; // Название аэропорта

        public Airport(string name)
        {
            Id = Guid.NewGuid();
            this.Name = name;
        }

        public Guid Id { get => id; set => id = value; } // Свойства
        public string Name { get => name; set => name = value; }

        public int CompareTo(Airport other) // Сравнение по названию (IComparable<Airport>)
        {
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj) // Является ли переданный объект типа Airport
        {
            return Equals(obj as Airport);
        }

        public bool Equals(Airport other) // Равенство 2 аэропортов по их уникальному идентификатору (IEquatable<Airport>)
        {
            return other != null && this.Id.Equals(other.Id);
        }

        public override int GetHashCode() // Переопределения методов
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}