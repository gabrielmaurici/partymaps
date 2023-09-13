function addScrollListener(element, dotnetHelper) {
    element.addEventListener('scroll', function () {
        var scrollSum = element.clientHeight - element.scrollTop + 1;

        if (scrollSum === element.scrollHeight) {
            dotnetHelper.invokeMethodAsync('GetMessages');
            element.scrollTop = element.scrollTop + 100;
        }
    });
}