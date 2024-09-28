using rest_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace rest_api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;
        public DocumentController(ILogger<DocumentController> logger)
        {
            _logger = logger;
        }

        private static readonly List<Document> _documents = new List<Document>
        {
            new Document { Id = 1, Title = "Document #1"},
            new Document { Id = 2, Title = "Document #2"},
            new Document { Id = 3, Title = "Document #3"},
        };

        [HttpGet("")]
        public ActionResult GetHome()
        {
            return Ok("Hello world! Please upload a document.");
        }

        [HttpGet("documents")]
        public IEnumerable<Document> GetDocuments()
        {
            return _documents ;
        }

        [HttpGet("documents/{id}")]
        public ActionResult<Document> GetDocument(int id)
        {
            foreach (Document document in _documents)
            {
                if (document.Id == id)
                {
                return document;
                }
            }
            return NotFound();
        }

        [HttpPost("documents")]
        public ActionResult<Document> UploadDocument([FromBody] Document uploadDocument)
        {
            foreach (Document document in _documents)
            {
                if (document.Id == uploadDocument.Id)
                {
                   return Conflict($"Document with id={uploadDocument.Id} already exists.");
                }
            }
            _documents.Add(uploadDocument);
            return uploadDocument;
        }

        [HttpPut("documents")]
        public ActionResult<Document> UpdateDocument([FromBody] Document uploadDocument)
        {
            foreach (Document document in _documents)
            {
                if (document.Id == uploadDocument.Id)
                {
                    document.Title = uploadDocument.Title;
                    return document;
                }
            }
            return NotFound();
        }

        [HttpDelete("documents/{id}")]
        public ActionResult<Document> DeleteDocument(int id)
        {
            foreach (Document document in _documents)
            {
                if (document.Id == id)
                {
                    _documents.Remove(document);
                    return Ok($"Document with id={id} deleted.");
                }
            }
            return NotFound();
        }

    }
}
