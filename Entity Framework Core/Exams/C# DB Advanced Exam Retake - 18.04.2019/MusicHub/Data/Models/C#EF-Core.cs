the-c-programming


Провери дали накъде където полето не е задължително дали не трябва да null int? DateTime?
Провери имената на полета да не са сгрешени
провери имената на таблиците дали не са сгрешени

#hello#fundamentals

//SQL local server
ANGEL_LAPTOP\SQLEXPRESS
 ==================================================================
//IsValid
	   private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
=======================================================

            var xmlSerializer = new XmlSerializer(typeof(ImportTicketDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportTicketDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Customer> customers = new List<Customer>();
            StringBuilder sb = new StringBuilder();

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            var hallSeatsDto = JsonConvert.DeserializeObject<ImportHallSeatDto[]>(jsonString);
            List<Hall> halls = new List<Hall>();

            StringBuilder sb = new StringBuilder();
		
===================================================
		[Key]
		public int Id { get; set; }


// Username
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }
		
// Name
        [Required]
        [MinLength(3), MaxLength(40)]
		public string Name { get; set; }
		
// FirstName
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }
		
// LastName
        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }
// Age
		[Required]
        [Range(12,110)]
        public int Age { get; set; }

//GameId	- ForeignKey	
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
		
// Price
		[Required]	
		[Range(typeof(decimal), "0", "79228162514264337593543950335")]
		public decimal Price { get; set; }
		
		[Required]
		[Range(0.0, double.MaxValue)]
		public decimal Price { get; set; }

//TimeSpan		
		[Required]
        public TimeSpan Duration { get; set; }

//DateTime
        [Required]
        public DateTime CreatedOn { get; set; }
		
//Number - Credit Card Number		
		[Required]
        [RegularExpression(@"\d{4} \d{4} \d{4} \d{4}")]
        public string Number { get; set; }
		
// Cvc - Credit Card		
        [Required]
        [RegularExpression(@"\d{3}")]
        public string Cvc { get; set; }
		
// ProductKey
        [Required]
        [RegularExpression(@"^[\dA-Z]{4}-[\dA-Z]{4}-[\dA-Z]{4}$")]
        public string ProductKey { get; set; }
		
// FullName
        [Required]
        [RegularExpression(@"[A-Z][a-z]+ [A-Z][a-z]+")]
        public string FullName { get; set; }
		
// PhoneNumber
        [RegularExpression(@"\+359 [0-9]{3} [0-9]{3} [0-9]{3}")]
        public string PhoneNumber { get; set; }		
		
		
		
//---
            builder.Entity<SongPerformer>()
                .HasKey(k => new
                {
                    k.SongId,
                    k.PerformerId
                });
				
				
				
==============================
CreateMap<ImportWriterDto, Writer>();

    CreateMap<ImportAlbumDto, Album>();
    CreateMap<ImportProducerDto, Producer>();

    CreateMap<ImportSongDto, Song>()
        .ForMember(t => t.Duration, y => y.MapFrom(k => TimeSpan.ParseExact(k.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture)))
        .ForMember(t => t.CreatedOn, y => y.MapFrom(k => DateTime.ParseExact(k.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));

  //  CreateMap<ImportProducerDto, Performer>();
   // CreateMap<ImportPerformerSongDto, SongPerformer>()
    //    .ForMember(t => t.SongId, y => y.MapFrom(k => k.Id));
			
			
			
+++++++++++++++++++++++++++++++++++++

//movies е List<Movie>
 var validateTitle = movies.Any(t => t.Title == movieDto.Title);
 var validDto = IsValid(movieDto);
 var isValidEnum = Enum.TryParse(typeof(Genre), movieDto.Genre, out object genre);


Genre = Enum.Parse<Genre>(dto.Genre)

ExecutionType = Enum.Parse<ExecutionType>(taskDto.ExecutionType),

LabelType = Enum.Parse<LabelType>(taskDto.LabelType)

//ExecutionType е името на самия "enum"
ExecutionType = (ExecutionType)Enum.ToObject(typeof(ExecutionType), taskDto.ExecutionType),

LabelType = (LabelType)Enum.ToObject(typeof(LabelType), taskDto.LabelType)

//Валидация на Enum преди DTO
bool isWeaponValid = Enum.TryParse(dto.Weapon, out Weapon weapon)




Duration = TimeSpan.ParseExact(dto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture),

CreatedOn = DateTime.ParseExact(dto.CreatedOn, @"dd/MM/yyyy",CultureInfo.InvariantCulture),


OpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),




//Когато дата може да е нул да направим проверка  null

DateTime dt; // Тази променлива се прави преди създаването на макета от данни ( за дадената таблица )


DueDate = DateTime
 .TryParseExact(projectDto.DueDate,
 "dd/MM/yyyy",
 CultureInfo.InvariantCulture,
 DateTimeStyles.None,
 out dt) ? dt : (DateTime?)null
								   
//Когато пропъртито e Дата и е може да е null					   
 DueDate = 	dto.DueDate == null ? new DateTime?() : DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

//Това като подават празен стринг освен null и той е валиден 
var dueDate = string.IsNullOrEmpty(dto.DueDate)
    ? new DateTime?()
    : DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


++++++++++++++++++++++++++++++++++++++++
•	Price – calculated property(the sum of all song prices in the album)
public decimal Price => this.Songs.Sum(p => p.Price);

































