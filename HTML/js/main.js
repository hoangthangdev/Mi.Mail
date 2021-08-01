// ======Home=full-pages=======
//using document ready...
$(document).ready(function() {

    //initialising fullpage.js in the jQuery way
    $('#fullpage').fullpage({
        sectionsColor: ['#E5E5E5'],
        navigation: true,
        slidesNavigation: true,
    });

    // calling fullpage.js methods using jQuery
    $('#moveSectionUp').click(function(e) {
        e.preventDefault();
        $.fn.fullpage.moveSectionUp();
    });

    $('#moveSectionDown').click(function(e) {
        e.preventDefault();
        $.fn.fullpage.moveSectionDown();
    });
});

// ==========slide-product===========
$(document).ready(function() {
    $('.slide-product').slick({
        centerMode: true,
        autoplay: true,
        arrows: false,
        // centerPadding: '60px',
        slidesToShow: 3,
        responsive: [{
            breakpoint: 768,
            settings: {
                arrows: false,
                centerMode: true,
                // centerPadding: '40px',
                slidesToShow: 3
            }
        }, {
            breakpoint: 480,
            settings: {
                arrows: false,
                centerMode: true,
                // centerPadding: '40px',
                slidesToShow: 1
            }
        }]
    });
    $('.next-2').click(function() {
        $(".slide-product").slick('slickNext');
    });
    $('.pre-2').click(function() {
        $(".slide-product").slick('slickPrev');
    });
});
// =========tab================
$(document).ready(function() {
        $('ul.tabs li').click(function() {
            var tab_id = $(this).attr('data-tab');
            $('ul.tabs li').removeClass('current');
            $('.tab-cusdb').removeClass('current');
            $(this).addClass('current');
            $("#" + tab_id).addClass('current');
        });
    })
    // --------------chart----------
var a = randomScalingFactor();
var a1 = randomScalingFactor();
var b = randomScalingFactor();
var b1 = randomScalingFactor();
var c = randomScalingFactor();
var c1 = randomScalingFactor();
var d = randomScalingFactor();
var d1 = randomScalingFactor();
var e = randomScalingFactor();
var e1 = randomScalingFactor();
var f = randomScalingFactor();
var f1 = randomScalingFactor();
var g = randomScalingFactor();
var g1 = randomScalingFactor();

var barChartData = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
    datasets: [{
        label: 'Tổng',
        backgroundColor: 'transparent',
        borderColor: '#ffab1b',
        data: [
            a + a1, b + b1, c + c1, d + d1, e + e1, f + f1, g + g1
        ],
        type: 'line'
    }, {
        label: 'Thành công',
        backgroundColor: '#3f4fa5',
        data: [
            a, b, c, d, e, f, g
        ]
    }, {
        label: 'Thất bại',
        backgroundColor: '#ed5159',
        data: [
            a1, b1, c1, d1, e1, f1, g1
        ]
    }]

};
window.onload = function() {
    var ctx = document.getElementById('canvas').getContext('2d');
    window.myBar = new Chart(ctx, {
        type: 'bar',
        data: barChartData,
        options: {
            title: {
                display: true,
                text: 'Chart.js Bar Chart - Stacked'
            },
            tooltips: {
                mode: 'index',
                intersect: false
            },
            responsive: true,
            scales: {
                xAxes: [{
                    stacked: true,
                }],
                yAxes: [{
                    stacked: true
                }]
            }
        }
    });
};
// ---------------Process-DASHBOARD---------
var percentage = 69.69;
var bar = new ProgressBar.SemiCircle('#process-bar-container', {
    strokeWidth: 6,
    color: '#000000',
    trailColor: '#eee',
    trailWidth: 1,
    easing: 'easeInOut',
    duration: 1400,
    svgStyle: null,
    text: {
        value: '',
        alignToBottom: false
    },
    from: {
        color: '#FFEA82'
    },
    to: {
        color: '#F26D21'
    },
    // Set default step function for all animate calls
    step: (state, bar) => {
        bar.path.setAttribute('stroke', state.color);
        var value = percentage;
        if (value === 0) {
            bar.setText('');
        } else {
            bar.setText(value + "%");
        }

        bar.text.style.color = state.color;
    }
});

bar.text.style.fontFamily = '"Raleway", Helvetica, sans-serif';
bar.text.style.fontSize = '36px';
bar.animate(percentage / 100); // Number from 0.0 to 1.0

// ---------------Process-khách hàng---------