/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/
/* */
/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/
const getElement = id => document.getElementById(id);
const getElements = className => document.getElementsByClassName(className);
const menu = getElement('menu');
const slideMenu = getElement('slide')
const content = getElement('content')
const overlay = getElement('overlay');
const logo = getElement('logoSlide');
const contIcon = getElements('cont-icon');
var isOpen = false
const settingsIcon = getElement('settingsIcon');
const optionsMenu = getElement('optionsMenu');
const nav = getElement('navbarResponsivo');


/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/
/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/
const toggleMenu = () => {

    slideMenu.style.width = isOpen ? '5%' : '15%';
    content.style.width = isOpen ? '95%' : '85%';
    menu.src = isOpen ? "/images/svg/bars-solid.svg" : "/images/svg/circle-xmark-regular.svg";
    overlay.style.display = isOpen ? 'none' : 'block';
    logo.style.visibility = isOpen ? 'hidden' : 'visible';
    const justifyContentValue = isOpen ? 'center' : 'flex-end';
    Array.from(contIcon).forEach(item => item.style.justifyContent = justifyContentValue);
    isOpen = !isOpen
}


menu.onclick = toggleMenu;
overlay.onclick = toggleMenu;

/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/
/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/


window.onresize = function () {
    var widthScreen = window.innerWidth;

    if (widthScreen > 990) {
        isOpen = false;
        nav.classList.remove("show");
        optionsMenu.style.display = 'none';
    } else if (widthScreen < 991) {
        isOpen = false;
    }
    isOpen = !isOpen;
    toggleMenu(isOpen);
};
/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/
/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/

settingsIcon.onclick = () => {
    optionsMenu.style.display = (optionsMenu.style.display === 'block') ? 'none' : 'block';
};


document.onclick = event => {
    if (!optionsMenu.contains(event.target) && event.target !== imagenClickable) {
        optionsMenu.style.display = 'none';
    }
};

/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/
/*°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°*/

