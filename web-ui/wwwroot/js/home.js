const apiUrl = 'http://localhost:8081/documents';

// Fetch documents
function fetchAllDocuments() {
    console.log('Fetching Document items...');
    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            const documentList = document.getElementById('documentList');
            documentList.innerHTML = ''; // Clear the list before appending new items
            data.forEach(docElement => {
                const doc = document.createElement("div");
                doc.className = "card mb-2 w-25"
                doc.innerHTML = `
                    <div class="card-body"><p class="card-text">Id: ${docElement.id} | Name: ${docElement.title}</p></div>
                `;
                documentList.appendChild(doc);
            });
        })
        .catch(error => console.error('Error while fetching documents...', error));
}

// Load items on page load
document.addEventListener('DOMContentLoaded', fetchAllDocuments);
