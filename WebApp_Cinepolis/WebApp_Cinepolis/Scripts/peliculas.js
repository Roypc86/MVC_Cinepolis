var textarea = document.querySelector('textarea');

textarea.addEventListener('keydown', autosize);
document.addEventListener("DOMContentLoaded", autosize_onload);

function autosize() {
    var el = this;
    setTimeout(function () {
        el.style.cssText = 'height: fit-content; padding:0; width: 100%;';
        el.style.cssText = 'height:' + el.scrollHeight + 'px; width: 100%;';
        
    }, 0);
}

function autosize_onload() {
    var el = textarea;
    setTimeout(function () {
        textarea.style.cssText = 'height: fit-content; padding:0; width: 100%;';
        textarea.style.cssText = 'height:' + el.scrollHeight + 'px; width: 100%;';
    }, 0);
}