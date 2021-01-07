
var waypoint1 = new Waypoint({
    element: document.getElementById('row_project_0'),
    handler: function (direction) {
        console.log('I am 20px from the top of the window 0')
        $('#row_project_0').addClass('animate__animated animate__bounceInRight')
        
    },
    offset: '80%'
});

var waypoint2 = new Waypoint({
    element: document.getElementById('row_project_1'),
    handler: function (direction) {
        console.log('I am 20px from the top of the window 1')
        $('#row_project_1').addClass('animate__animated animate__bounceInLeft')

    },
    offset: '80%'
});

var waypoint3 = new Waypoint({
    element: document.getElementById('row_project_2'),
    handler: function (direction) {
        console.log('I am 20px from the top of the window 2')
        $('#row_project_2').addClass('animate__animated animate__bounceInRight')
    },
    offset: '80%'
});

var waypoint4 = new Waypoint({
    element: document.getElementById('row_project_3'),
    handler: function (direction) {
        console.log('I am 20px from the top of the window 3')
        $('#row_project_3').addClass('animate__animated animate__bounceInLeft')

    },
    offset: '80%'
});
