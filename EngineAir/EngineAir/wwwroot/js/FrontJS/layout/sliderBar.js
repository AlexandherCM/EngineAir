document.addEventListener("DOMContentLoaded", function () {
    /* ------------- CONSTANTS ------------------ */
    const getElement = id => document.getElementById(id);
    const getElements = className => document.getElementsByClassName(className);

    /* ------------- CONSTANTS ------------------ */
    let icon = getElement('bars');
    let menu = getElement('menu');
    let content = getElement('content');
    let logo = getElement('slider-logo');
    let overlay = getElement('overlay');
    let settings = getElement('settingsIcon');
    let optionsMenu = getElement('optionsMenu');
    var isOpen = false;
    let contIcon = getElements('content-bars');

    /* ------------- SLIDER ------------------ */

    const sliderMenu = () => {
        menu.style.width = isOpen ? '5%' : '15%';
        icon.src = isOpen ? "/images/svg/bars-solid.svg" : "/images/svg/circle-xmark-regular.svg";
        content.classList = isOpen ? 'content' : 'contentW';
        logo.style.visibility = isOpen ? 'hidden' : 'visible';
        overlay.style.display = isOpen ? 'none' : 'block';
        let justifyContentValue = isOpen ? 'center' : 'flex-end';
        Array.from(contIcon).forEach(item => item.style.justifyContent = justifyContentValue);

        isOpen = !isOpen;
    }
    icon.onclick = sliderMenu;
    overlay.onclick = sliderMenu;

    /* ------------- SETTINGS ------------------ */

    settings.onclick = () => {
        optionsMenu.style.display = (optionsMenu.style.display === 'block') ? 'none' : 'block';
    };


    document.onclick = event => {
        if (!optionsMenu.contains(event.target) && event.target !== settings) {
            optionsMenu.style.display = 'none';
        }
    };

    /* ------------- RESPONSIVE ------------------ */
    window.onresize = function () {
        var widthScreen = window.innerWidth;

        if (widthScreen > 990) {
            isOpen = true;

        } else if (widthScreen < 991) {
            isOpen = true;

        }
        sliderMenu(isOpen);
        isOpen = !isOpen;
    };

});
