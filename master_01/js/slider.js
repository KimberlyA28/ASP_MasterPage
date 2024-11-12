let currentIndex = 0;
const slides = document.querySelectorAll('.slide');
const totalSlides = slides.length;

function changeSlide() {
    // Ocultar la imagen actual
    slides[currentIndex].style.display = 'none';

    // Incrementar el índice para mostrar la siguiente imagen
    currentIndex = (currentIndex + 1) % totalSlides;

    // Mostrar la siguiente imagen
    slides[currentIndex].style.display = 'block';
}

// Inicializar el slider
function initSlider() {
    // Ocultar todas las imágenes excepto la primera
    slides.forEach((slide, index) => {
        if (index !== currentIndex) {
            slide.style.display = 'none';
        }
    });

    // Cambiar la imagen cada 3 segundos
    setInterval(changeSlide, 3000);
}

// Llamar a la función de inicialización cuando la página cargue
window.onload = initSlider;
