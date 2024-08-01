using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VocabularyBuilder.App.Interfaces;
using VocabularyBuilder.Domain.CustomException;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VocabularyController : ControllerBase
    {
        private readonly IVocabularyService _vocabService;

        public VocabularyController(IVocabularyService vocabService)
        {
            _vocabService = vocabService;
        }
        [HttpGet("allbyId")]
        public async Task<ActionResult<IEnumerable<Vocabulary>>> GetAll()
        {
            try

            {
                var result = await _vocabService.GetAllVocabularies();
                return Ok(result);

            }
            catch (NotFoundException e)

            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{word}")]
        public async Task<ActionResult<Vocabulary>> GetbyWord(string word)
        {
            try
            {
                var result = await _vocabService.GetVocabularyByFilter(x => x.Word == word);
                return Ok(result);

            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }


        }
        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<Vocabulary>> GetbyId(int id)
        {
            try
            {
                var resultado = await _vocabService.GetVocabularyByFilter(x => x.Id == id);
                return Ok(resultado);
            }
            catch (NotFoundException e)

            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Vocabulary>> Post(Vocabulary vocabulary)
        {
            try
            {
                var resultado = await _vocabService.SaveVocabulary(vocabulary);
                return Ok(resultado);
            }
            catch (AlreadyExistsException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<Vocabulary>> Put(int id, Vocabulary vocab)
        {
            try
            {
                var resultado = await _vocabService.UpdateVocabulary(vocab, id);
                return Ok(resultado);
            }
            catch (NotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<Vocabulary>> Delete(string word)
        {
            try
            {
                var resultado = await _vocabService.DeleteVocabulary(word);
                return Ok(resultado);
            } catch (NotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
