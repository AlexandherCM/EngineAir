document.addEventListener("DOMContentLoaded", function () {
    const darkModeSwitch = document.getElementById('darkModeSwitch');
    const body = document.getElementById('body');
    const localInitial = localStorage.getItem('darkModeState');
    const render = document.getElementById('render');
    const navMovil = document.getElementById('navbar')

    if (darkModeSwitch !== null) {
       
        const isDarkModeEnabled = localInitial === 'true';

        
        if (isDarkModeEnabled) {
            enableDarkMode();
        }
    }

   
    function enableDarkMode() {
        body.classList.remove('bg-graylight');
        body.classList.add('bg-grayDark');
        render.classList.add('text-light');
        render.classList.remove('text-dark');
        localStorage.setItem("darkModeState", "true");
        navMovil.classList.remove('navbar-light');
        navMovil.classList.add('navbar-dark');
        darkModeSwitch.checked = true;
    }

    
    function disableDarkMode() {
        body.classList.remove('bg-grayDark');
        body.classList.add('bg-graylight');
        render.classList.remove('text-light');
        render.classList.add('text-dark');
        navMovil.classList.add('navbar-light');
        navMovil.classList.remove('navbar-dark');

        localStorage.setItem("darkModeState", "false");
        darkModeSwitch.checked = false;
    }

 
    darkModeSwitch.addEventListener("change", function () {
        if (darkModeSwitch.checked) {
            enableDarkMode();
        } else {
            disableDarkMode();
        }
    });
});



