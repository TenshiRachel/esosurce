$(function () {
    const searchInput = $('#action-search-input');

    if (searchInput) {
        searchInput.on('keyup', function () {
            search(searchInput.val());
        })
    }
});

function search(input) {
    let filter = input.toUpperCase();
    let cards = $('.data-rows');
    let name = $('.name');

    for (let i = 0, n = cards.length; i < n; i++) {
        let focus = $(cards[i]);
        let compare = $(name[i]).data('name');

        if (compare.toUpperCase().includes(filter)) {
            if ($(focus).hasClass('d-none')) {
                $(focus).removeClass('d-none');
                $(focus).addClass('animated faster fadeIn').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeIn');
                });
            }
        }
        else {
            if (!$(focus).hasClass('d-none')) {
                $(focus).addClass('animated faster fadeOut').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeOut');
                    _this.addClass('d-none');
                })
            }
        }
    }
}