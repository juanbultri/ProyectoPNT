// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function listenerPerfil() {
    let perfil = document.getElementById("Perfil");
    let group_plan = document.getElementById("grupo_plan");
    let plan = document.getElementById("Plan");

    if (perfil.value != 2) {
        group_plan.style.display = "none";
        plan.value = "";
    } else {
        group_plan.style.display = "";
    }
}