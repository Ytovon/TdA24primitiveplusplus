window.onload = function () {
    // Wrap your code in a function to avoid polluting the global namespace
    (function () {
        var scrollsize = 250;

        function scrollLeftSmooth(element) {
            setTimeout(() => {
                element.scrollTo({
                    left: element.scrollLeft - scrollsize,
                    behavior: 'smooth'
                });
            }, 80);
        }

        function scrollRightSmooth(element) {
            setTimeout(() => {
                element.scrollTo({
                    behavior: 'smooth',
                    left: element.scrollLeft + scrollsize,
                });
            }, 80);
        }

        document.querySelectorAll('.tags').forEach(function (element) {
            var prevButton = element.querySelector('.prev_btn');
            var nextButton = element.querySelector('.next_btn');

            prevButton.addEventListener('click', function () {
                scrollLeftSmooth(element);
            });

            nextButton.addEventListener('click', function () {
                scrollRightSmooth(element);
            });
        });
    })();
};


window.initializeScrolling = function (element) {
    var scrollsize = 250;

    function scrollLeftSmooth(element) {
        setTimeout(() => {
            element.scrollTo({
                left: element.scrollLeft - scrollsize,
                behavior: 'smooth'
            });
        }, 80);
    }

    function scrollRightSmooth(element) {
         setTimeout(() => {
                element.scrollTo({
                    behavior: 'smooth',
                    left: element.scrollLeft + scrollsize,
                });
            }, 80);
    }

    document.querySelectorAll('.tags').forEach(function (element) {
        var prevButton = element.querySelector('.prev_btn');
        var nextButton = element.querySelector('.next_btn');

        prevButton.addEventListener('click', function () {
            scrollLeftSmooth(element);
        });

        nextButton.addEventListener('click', function () {
            scrollRightSmooth(element);
        });
    });
};
