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
            pupilsContainer.innerHTML = '';

            data.forEach(pupil => {
                const pupilElement = document.createElement('div');
                pupilElement.classList.add('tile');

                pupilElement.innerHTML = `
                    <img src="${pupil.imageUrl}" alt="${pupil.name}" class="user-image" />
                    <h3>${pupil.name}</h3>
                    <p>${pupil.email}</p>
                `;
                pupilsContainer.appendChild(pupilElement);
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
