using Application.Dto;
using Domain.Entities;
using Repository;
using Repository.Repository;
using System.Text.Json;

namespace Application.Services
{
    public class FolderService
    {
        private readonly string _jsonPath = $@"{Directory.GetCurrentDirectory()}\Folders";
        private readonly NoteRepository _noteRepository;
        private string _FolderPath;

        public FolderService(NoteRepository noteRepository, string folderPath)
        {
            _noteRepository = noteRepository;
            _FolderPath = folderPath;
        }

        public BaseDto CreateFolderAndFile(string folderName)
        {
            CreateBaseDirectory(_jsonPath);

            string fullJsonPath = Path.Combine(_jsonPath, folderName + ".json");

            SaveToFile(folderName, fullJsonPath);

            return new BaseDto(200, "Nova pasta criada");
        }

        private void CreateBaseDirectory(string jsonDirectory)
        {
            if (Directory.Exists(jsonDirectory) == false)
            {
                Directory.CreateDirectory(jsonDirectory);
            }
        }

        private void DeleteExistingFile(string fullJsonPath)
        {
            if (File.Exists(fullJsonPath))
            {
                File.Delete(fullJsonPath);
            }
        }

        private void SaveToFile(string jsonFileName, string fullJsonPath)
        {
            JsonTemplate template = new JsonTemplate();
            template.Name = jsonFileName;

            File.WriteAllText(fullJsonPath, Newtonsoft.Json.JsonConvert.SerializeObject(template));
        }
        public BaseDto Move(Guid userID, string tittle, string folderName)
        {
            var note = _noteRepository.GetNote(tittle, userID);

            _FolderPath = @$"{_jsonPath}\{folderName}";

            Add(note);

            return new BaseDto(200, $"Anotação movida para {folderName}");
        }
        private void Add(NoteEntity entity)
        {
            var list = GetAll();

            list.Add(entity);

            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(_FolderPath, json);
        }
        private List<NoteEntity> GetAll()
        {
            using (StreamReader r = new StreamReader(_FolderPath))
            {
                string json = r.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<NoteEntity>();
                }

                return JsonSerializer.Deserialize<List<NoteEntity>>(json);
            }
        }
    }
}
