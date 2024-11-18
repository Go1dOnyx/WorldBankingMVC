const indicators = document.querySelectorAll('.indicator');
const images = document.querySelector('.carousel-body');
let currentSlide = 0;

function showSlide(index) {
    images.style.transform = 'translateX(' + (-index * 100) + '%)';
    indicators.forEach((indicator, i) => {
        indicator.classList.toggle('active', i === index);
    });
}

function nextSlide() {
    currentSlide = (currentSlide + 1) % indicators.length;
    showSlide(currentSlide);
}

setInterval(nextSlide, 3500); // Change slide every 3 seconds
