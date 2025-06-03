<script>
document.addEventListener("DOMContentLoaded", function () {
     const form = document.getElementById("banchet-form");
     const isUserLoggedIn = @User.Identity.IsAuthenticated.ToString().ToLower();

     form.addEventListener("submit", function (event) {
          const tipBanchet = form.querySelector('[name="TipBanchet"]').value;
          const nrPersoane = form.querySelector('[name="NrPersoane"]').value;
          const dataRezervare = form.querySelector('[name="DataRezervare"]').value;
          const oraRezervare = form.querySelector('[name="OraRezervare"]').value;
          const nrTelefon = form.querySelector('[name="NrTelefon"]').value;

          if (!tipBanchet || !nrPersoane || !dataRezervare || !oraRezervare || !nrTelefon) {
               event.preventDefault();
               alert("Te rugăm să completezi toate câmpurile.");
               return;
          }

          if (!/^[0-9]{9}$/.test(nrTelefon)) {
               event.preventDefault();
               alert("Numărul de telefon trebuie să conțină exact 9 cifre.");
               return;
          }

          const dataOraSelectata = new Date(`${dataRezervare}T${oraRezervare}`);
          const dataCurenta = new Date();

          if (dataOraSelectata <= dataCurenta) {
               event.preventDefault();
               alert("Data și ora rezervării trebuie să fie în viitor.");
               return;
          }

          if (!isUserLoggedIn) {
               event.preventDefault();
               alert("Trebuie să fii autentificat pentru a trimite o rezervare.");
               window.location.href = "/Auth/Authentification";
               return;
          }
     });
});
</script>
