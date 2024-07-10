async function fetchCatFact() {
    try {
        const response = await fetch('/Placeholder/api/posts');
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        document.getElementById('jsonPost').innerText = data.fact;
        const imageUrl = data.fact; // Use data.fact as the image source
        const catImage = document.getElementById('catImage');
        catImage.src = imageUrl;
        catImage.style.display = 'block';
    } catch (error) {
        console.error('Error fetching cat fact:', error);
    }
}

window.onload = fetchCatFact;


