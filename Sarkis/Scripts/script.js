const cartIcon = document.querySelector("#cart-icon");
const cart = document.querySelector(".cart");
const cartClose = document.querySelector("#cart-close");
cartIcon.addEventListener("click", () => cart.classList.add("active"));
cartClose.addEventListener("click", () => cart.classList.remove("active"));

const addCartButtons = document.querySelectorAll(".add-cart");
addCartButtons.forEach(button => {
    button.addEventListener("click", event => {
        const productBox = event.target.closest(".product-box");
        addToCart(productBox);
        const name = productBox.querySelector(".product-title").textContent.trim();
        const priceText = productBox.querySelector(".price").textContent.trim();
        const price = parseFloat(priceText.replace("lei", "").trim());

        const existing = cartItems.find(item => item.nume === name);
        if (existing) {
            existing.cantitate++;
        } else {
            cartItems.push({ nume: name, pret: price, cantitate: 1 });
        }
    });
});

const cartContent = document.querySelector(".cart-content");

const addToCart = (productBox) => {
    const productImgSrc = productBox.querySelector(".img-box img").src;
    const productTitle = productBox.querySelector(".product-title").textContent;
    const productPrice = productBox.querySelector(".price").textContent;

    const cartItems = cartContent.querySelectorAll(".cart-product-title");
    for (let item of cartItems) {
        if (item.textContent === productTitle) {
            alert("This item is already in the cart.");
            return;
        }
    }

    const cartBox = document.createElement("div");
    cartBox.classList.add("cart-box");
    cartBox.innerHTML = `
        <img src="${productImgSrc}" class="cart-img">
        <div class="card-detail">
            <h2 class="cart-product-title">${productTitle}</h2>
            <span class="cart-price">${productPrice}</span>
            <div class="cart-quantity">
                <button class="decrement">-</button>
                <span class="number">1</span>
                <button class="increment">+</button>
            </div>
        </div>
        <i class="ri-delete-bin-line cart-remove"></i>
    `;

    cartContent.appendChild(cartBox);
    cart.classList.add("active");

    cartBox.querySelector(".cart-remove").addEventListener("click", () => {
        cartBox.remove();

        updateCartCount(-1);

        updateTotalPrice();
    });

    cartBox.querySelector(".cart-quantity").addEventListener("click", event => {
        const numberElement = cartBox.querySelector(".number");
        const decrementButton = cartBox.querySelector(".decrement");
        let quantity = parseInt(numberElement.textContent);

        if (event.target.classList.contains("decrement") && quantity > 1) {
            quantity--;
        } else if (event.target.classList.contains("increment")) {
            quantity++;
        }

        numberElement.textContent = quantity;
        updateTotalPrice();
    });
    updateCartCount(1);

    updateTotalPrice();
};

const updateTotalPrice = () => {
    const totalPriceElement = document.querySelector(".total-price");
    const cartBoxes = cartContent.querySelectorAll(".cart-box");
    let total = 0;

    cartBoxes.forEach(cartBox => {
        const priceElement = cartBox.querySelector(".cart-price");
        const quantityElement = cartBox.querySelector(".number");
        let price = parseFloat(priceElement.textContent.replace("lei", "").trim());
        let quantity = parseInt(quantityElement.textContent);

        if (!isNaN(price) && !isNaN(quantity)) {
            total += price * quantity;
        }
    });

    totalPriceElement.textContent = `${total} lei`;
};

let cartItemCount = 0;
let cartItems = [];
const updateCartCount = (change) => {
    const cartItemCountBadge = document.querySelector(".cart-item-count");
    cartItemCount += change;
    if (cartItemCount > 0) {
        cartItemCountBadge.style.visibility = "visible";
        cartItemCountBadge.textContent = cartItemCount;
    } else {
        cartItemCountBadge.style.visibility = "hidden";
        cartItemCountBadge.textContent = "";
    }
};



document.addEventListener("DOMContentLoaded", function () {
    const modal = document.getElementById("reservation-modal");
    const closeModalBtn = document.getElementById("close-modal");
    const confirmBtn = document.getElementById("confirm-reservation");
    const eventDateInput = document.getElementById("event-date");
    const eventTimeInput = document.getElementById("event-time");
    const buyNowButton = document.getElementById("buy-now-button");

    function setMinDateTime() {
        const now = new Date();
        const yyyy = now.getFullYear();
        const mm = String(now.getMonth() + 1).padStart(2, '0');
        const dd = String(now.getDate()).padStart(2, '0');
        const hh = String(now.getHours()).padStart(2, '0');
        const min = String(now.getMinutes()).padStart(2, '0');

        eventDateInput.min = `${yyyy}-${mm}-${dd}`;
        eventTimeInput.min = `${hh}:${min}`;
    }

    setMinDateTime();

    buyNowButton.addEventListener("click", () => {
        modal.style.display = "flex";
        setMinDateTime();
    });

    closeModalBtn.addEventListener("click", function () {
        modal.style.display = "block";
    });

    confirmBtn.addEventListener("click", (e) => {
        e.preventDefault();

        // Verifică autentificarea (exemplu cu localStorage)
        const isAuthenticated = localStorage.getItem("isAuthenticated") === "true";
        const isLoggedIn = localStorage.getItem("isLoggedIn") === "true";


        if (!isAuthenticated && isLoggedIn) {
            alert("Trebuie să fii autentificat pentru a face o rezervare.");
            window.location.href = "/Auth/Authentification?returnUrl=/Reservations/Create";;
            return;
        }

        const dateValue = eventDateInput.value;
        const timeValue = eventTimeInput.value;
        const numPersons = document.getElementById("num-persons").value;
        const eventType = document.getElementById("event-type").value;

        if (!dateValue || !timeValue || !numPersons || !eventType || !phoneNumber) {
            alert("Te rog completează toate câmpurile.");
            return;
        }

        // Validare telefon (poți adapta după nevoi)
        const phoneRegex = /^[0-9\s\-+()]{7,15}$/;
        if (!phoneRegex.test(phoneNumber)) {
            alert("Te rog să introduci un număr de telefon valid.");
            return;
        }


        const selectedDateTime = new Date(`${dateValue}T${timeValue}`);
        const now = new Date();

        if (selectedDateTime <= now) {
            alert("Data și ora trebuie să fie în viitor.");
            return;
        }

        alert(`Rezervarea a fost înregistrată:\nData: ${dateValue}\nOra: ${timeValue}\nPersoane: ${numPersons}\nTip: ${eventType}\nTelefon: ${phoneNumber}`);

        modal.style.display = "none";
    });
});
const rezervareButton = document.getElementById("reserve-button");
if (rezervareButton) {
    rezervareButton.addEventListener("click", () => {
        const form = document.getElementById("reservation-form");
        if (!form) return;

        // Șterge câmpurile vechi
        form.querySelectorAll(".hidden-bucate").forEach(el => el.remove());

        // Adaugă câmpuri hidden pentru fiecare bucată
        cartItems.forEach((item, index) => {
            ["nume", "pret", "cantitate"].forEach(key => {
                const input = document.createElement("input");
                input.type = "hidden";
                input.name = `BucateComandate[${index}].${key.charAt(0).toUpperCase() + key.slice(1)}`;
                input.value = item[key];
                input.classList.add("hidden-bucate");
                form.appendChild(input);
            });
        });
    });
}


/**
   * Preloader
   */
let preloader = select('#preloader');
if (preloader) {
    window.addEventListener('load', () => {
        preloader.remove()
    });
}


/**
 * Menu isotope and filter
 */
window.addEventListener('load', () => {
    let menuContainer = select('.menu-container');
    if (menuContainer) {
        let menuIsotope = new Isotope(menuContainer, {
            itemSelector: '.menu-item',
            layoutMode: 'fitRows'
        });

        let menuFilters = select('#menu-flters li', true);

        on('click', '#menu-flters li', function (e) {
            e.preventDefault();
            menuFilters.forEach(function (el) {
                el.classList.remove('filter-active');
            });
            this.classList.add('filter-active');

            menuIsotope.arrange({
                filter: this.getAttribute('data-filter')
            });
            menuIsotope.on('arrangeComplete', function () {
                AOS.refresh()
            });
        }, true);
    }

});








