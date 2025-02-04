async function fetchPupils() {
    try {
        const response = await fetch('http://localhost:5000/api/trainers/1/all-pupils', {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
            },
        });

        if (response.ok) {
            const data = await response.json();
            const pupilsContainer = document.querySelector(".tiles-container");
            pupilsContainer.innerHTML = ''; // Clear existing tiles

            data.forEach(pupil => {
                const pupilElement = document.createElement('div');
                pupilElement.classList.add('tile');

                // Create an anchor tag with href pointing to ExercisesEdit page and pupilId
                const pupilLink = document.createElement('a');
                pupilLink.href = `/ExercisesEdit/${pupil.id}`; // The URL for ExercisesEdit page

                pupilLink.innerHTML = `
                    <img src="https://banner2.cleanpng.com/20180608/ujz/kisspng-computer-icons-overseas-development-institute-5b1aa7256b1f39.7111164315284733814388.jpg" alt="${pupil.name}" class="user-image" />
                    <h3>${pupil.name}</h3>
                    <p>${pupil.email}</p>
                `;
                pupilElement.appendChild(pupilLink); // Append the link inside the tile
                pupilsContainer.appendChild(pupilElement); // Append the tile to the container
            });
        } else {
            console.error('B³¹d odpowiedzi API:', response.statusText);
        }
    } catch (error) {
        console.error("B³¹d podczas zapytania:", error);
    }
}

// load function on dashboard enter
document.addEventListener('DOMContentLoaded', function () {
    fetchPupils();
});
