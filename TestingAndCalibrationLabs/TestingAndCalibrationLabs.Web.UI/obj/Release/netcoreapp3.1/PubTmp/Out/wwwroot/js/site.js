// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let WheelLoader = () => {
    // Gray out background on page
    $("body").addClass("submit-progress-bg");
    // Wrap in setTimeout so the UI can update the spinners
    setTimeout(function () {
        $("#snacResponse").removeClass("hidden");
    }, 1);
}
let HideWheelLoader = () => {
    $("body").removeClass("submit-progress-bg");
    // Wrap in setTimeout so the UI can update the spinners
    setTimeout(function () {
        $("#snacResponse").addClass("hidden");
    }, 1);
}