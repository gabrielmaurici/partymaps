namespace src.Domain.Entities
{
    public class Event
    {
        private string? _idCreator;
        private string? _name;
        private decimal _eventValue;


        public Event(string? idCreator, string? name, string? description, decimal eventValue, DateTime eventDate) 
        {
            this.IdCreator = idCreator;
            this.Name = name;
            this.Description = description;
            this.EventValue = eventValue;
            this.EventDate = eventDate;
            this.CreationDate = DateTime.Now;
        }

        public int Id { get; private set; }

        public string? IdCreator 
        { 
            get => _idCreator;
            private set {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Id do criador é obrigatório");

                _idCreator = value;
            }
        }

        public string? Name
        { 
            get => _name;
            private set {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Nome do evento é obrigatório");

                _name = value;
            }
        }

        public string? Description { get; private set; } = string.Empty;

        public decimal EventValue
        {    
            get => _eventValue;
            private set {
                if (value <= 0) throw new ArgumentException("Valor do evento é obrigatório");

                _eventValue = value;
            }
        }

        public DateTime EventDate { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime ChangeDate { get; private set; }


        public void Update(string? name, string? description, decimal eventValue, DateTime eventDate) {
            this.Name = name;
            this.Description = description;
            this.EventValue = eventValue;
            this.EventDate = eventDate;
            this.ChangeDate = DateTime.Now;
        }
    }
}