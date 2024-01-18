var scrollsize = 250;

function scrollLeftSmooth(element) {
    setTimeout(() => {
        element.scrollTo({
            left: element.scrollLeft - scrollsize,
            behavior: 'smooth'
        });
    }, 80); // Delay of 1000 milliseconds (1 second)
}

function scrollRightSmooth(element) {
    setTimeout(() => {
        element.scrollTo({
            behavior: 'smooth',
            left: element.scrollLeft + scrollsize, // Adjust the scroll distance as needed
        });
    }, 80); // Delay of 1000 milliseconds (1 second)
}
document.querySelectorAll('.tags').forEach(function (element) {
    var prevButton = element.querySelector('.predchozi_btn');
    var nextButton = element.querySelector('.dalsi_btn');

    prevButton.addEventListener('click', function () {
        scrollLeftSmooth(element);
    });

    nextButton.addEventListener('click', function () {
        scrollRightSmooth(element);
    });
});
