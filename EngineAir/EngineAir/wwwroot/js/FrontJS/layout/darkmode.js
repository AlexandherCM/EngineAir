﻿document.addEventListener("DOMContentLoaded", function () {

    /* ------------- CONSTANTS ------------------ */
    const getElement = id => document.getElementById(id);
    const getElements = className => document.getElementsByClassName(className);
    const body = document.body;
    const nav = getElement('nav');
    const darkModeSwitch = getElement('darkModeSwitch');
    const isDarkModeEnabled = localStorage.getItem('darkModeState') === 'true';
    let tables = getElements('table');
    let conTable = getElements('contable');


    /* ------------- FUNCTIONS ------------------ */
    function toggleDarkMode(enable) {
        const modeClass = enable ? 'dark' : 'light';
        body.classList.toggle('bg-darkgray', enable);
        body.classList.toggle('bg-lightgray', !enable);
        body.classList.toggle('text-light', enable);
        nav.classList.toggle('navbar-dark', enable);
        nav.classList.toggle('navbar-lighty', !enable);
        nav.classList.toggle('bg-kingdark', enable);
        nav.classList.toggle('bg-white', !enable);
        
        tables = Array.from(tables);
        tables.forEach(table => {
            table.classList.toggle('text-light', enable);
        });
        conTable = Array.from(conTable);
        conTable.forEach(conTable => {
            conTable.classList.toggle('bg-lightgray', enable);
            conTable.classList.toggle('bg-gray', !enable);
        });

        localStorage.setItem("darkModeState", enable.toString());
        darkModeSwitch.checked = enable;
    }
    
    if (darkModeSwitch) {
        toggleDarkMode(isDarkModeEnabled);
    }
    
    if (darkModeSwitch) {
        darkModeSwitch.addEventListener("change", function () {
            toggleDarkMode(this.checked);
        });
    }
});
