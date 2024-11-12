let slideIndex = 0;

function showSlides() {
    let slides = document.querySelectorAll('.slide');
    let totalSlides = slides.length;

    // Mueve el slider
    if (slideIndex >= totalSlides) {
        slideIndex = 0;
    } else if (slideIndex < 0) {
        slideIndex = totalSlides - 1;
    }

    // Aplica el desplazamiento
    const slidesContainer = document.querySelector('.slides');
    slidesContainer.style.transform = `translateX(-${slideIndex * 100}%)`;
}

function nextSlide() {
    slideIndex++;
    showSlides();
}

function prevSlide() {
    slideIndex--;
    showSlides();
}

// Inicializa el slider
document.addEventListener("DOMContentLoaded", function () {
    showSlides();
    // Añadir evento de botones
    const prevButton = document.createElement('button');
    prevButton.classList.add('prev');
    prevButton.innerHTML = 'Prev';
    prevButton.onclick = (e) => { e.preventDefault(); prevSlide(); };
    document.querySelector('.slider').appendChild(prevButton);

    const nextButton = document.createElement('button');
    nextButton.classList.add('next');
    nextButton.innerHTML = 'Next';
    nextButton.onclick = (e) => { e.preventDefault(); nextSlide(); };
    document.querySelector('.slider').appendChild(nextButton);
});
