document.addEventListener("DOMContentLoaded", function () {
    const darkModeSwitch = document.getElementById('darkModeSwitch');
    const body = document.getElementById('body');
    const localInitial = localStorage.getItem('darkModeState');
    const render = document.getElementById('render');

    if (darkModeSwitch !== null) {
       
        const isDarkModeEnabled = localInitial === 'true';

        
        if (isDarkModeEnabled) {
            enableDarkMode();
        }
    }

   
    function enableDarkMode() {
        body.classList.remove('bg-graylight');
        body.classList.add('bg-dark');
        render.classList.add('text-light');
        render.classList.remove('text-dark');
        localStorage.setItem("darkModeState", "true");
        
        darkModeSwitch.checked = true;
    }

    
    function disableDarkMode() {
        body.classList.remove('bg-dark');
        body.classList.add('bg-graylight');
        render.classList.remove('text-light');
        render.classList.add('text-dark');
       

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



