// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function DisplayLoader() {
    $('#Loader').show();
}

function HideLoader() {
    $('#Loader').hide();
}

$('#Loader').show();

//$(document).on('submit', 'form', function () {
//    DisplayLoader();
//})

$(window).on('beforeunload', function () {
    HideLoader();
})















