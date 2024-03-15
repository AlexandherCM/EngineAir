const getElement = id => document.getElementById(id);
const getElements = className => document.getElementsByClassName(className);

const openB = getElement('openBrand');
const formB = getElement('formBrand');
const closeB = getElement('closeBrand');

const openM = getElement('openModel');
const formM = getElement('formModel');
const closeM = getElement('closeModel');

const openC = getElement('openComponent');
const formC = getElement('formComponent');
const closeC = getElement('closeComponent');


const OpenCloseBrand = () => {
    if (formB.classList.contains('active')) {
        formB.classList.remove('active');
    } else {
        formB.classList.add('active');
    }
}

const openModel = () => {
    if (formM.classList.contains('active')) {
        formM.classList.remove('active');
    } else {
        formM.classList.add('active');

    }
}

const openComponent = () => {
    if (formC.classList.contains('active')) {
        formC.classList.remove('active');
    } else {
        formC.classList.add('active');

    }
}

openB.onclick = OpenCloseBrand;
closeB.onclick = OpenCloseBrand;

openM.onclick = openModel;
closeM.onclick = openModel;

openC.onclick = openComponent;
closeC.onclick = openComponent;
