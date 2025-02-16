



const priceRange = document.getElementById('price-range');
const priceLabel = document.getElementById('price-label');

priceRange.addEventListener('input', (event) => {
    priceLabel.textContent = event.target.value;
});

