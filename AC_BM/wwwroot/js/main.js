var swiper = new Swiper(".mySwiper", {
    slidesPerView: 3,
    spaceBetween: 30,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    breakpoints: {
        600: {
            slidesPerView: 2,
        },
        1024: {
            slidesPerView: 3,
        }
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});

debugger

const all = document.querySelectorAll(".navbar-nav .nav-link.toEffect");
all.forEach(f => {
    f.addEventListener("click", () => {
        debugger
        const navLink = document.querySelector(".navbar-nav .nav-link.toEffect.active");
        if (navLink) {
            navLink.classList.remove("active");
        }
        f.classList.add("active");
    })
    
    
})
