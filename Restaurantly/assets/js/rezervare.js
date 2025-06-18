document.addEventListener("DOMContentLoaded", function () {
  const form = document.querySelector(".php-email-form");
  const dataInput = document.getElementById("dataRezervare");
  const oraInput = document.getElementById("oraRezervare");

  if (!form || !dataInput || !oraInput) {
    console.error("Formularul sau inputurile nu au fost găsite.");
    return;
  }

  // Setăm data minimă la ziua de azi
  const today = new Date();
  const yyyy = today.getFullYear();
  const mm = String(today.getMonth() + 1).padStart(2, "0");
  const dd = String(today.getDate()).padStart(2, "0");
  const minDate = `${yyyy}-${mm}-${dd}`;
  dataInput.min = minDate;

  // Dacă data selectată este azi, limităm ora minimă la ora curentă
  dataInput.addEventListener("change", function () {
    const selectedDate = new Date(this.value);
    const todayDate = new Date(minDate);

    if (selectedDate.toDateString() === todayDate.toDateString()) {
      const now = new Date();
      const hh = String(now.getHours()).padStart(2, "0");
      const min = String(now.getMinutes()).padStart(2, "0");
      oraInput.min = `${hh}:${min}`;
    } else {
      oraInput.min = "00:00";
    }
  });

  form.addEventListener("submit", function (e) {
    e.preventDefault();

    const isAuthenticated = localStorage.getItem("isAuthenticated") === "true";
    const isLoggedIn = localStorage.getItem("isLoggedIn") === "true";

    if (isAuthenticated && isLoggedIn) {
      // Dacă este autentificat și logat, trimite formularul normal
      form.submit();
    } else {
      alert("Trebuie să fii autentificat și logat pentru a face o rezervare.");
      window.location.href = "authentification.html";}
  });
});
