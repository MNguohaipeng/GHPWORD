
var LoadTable = function (option) {
    LoadTableThead(option)
    LoadTableTbody(option)
    LoadTableTop(option)
      }
var LoadTableThead = function (option) {

 

    var thead = option.thead;

    var html = "<thead><tr>";
    $(thead).each(function (index, item) {

       
        html += "<th>" + item.name + "</th>"

    })



    html += "</tr></thead>";

    $("#GHPTABLE table").append(html);

}
var LoadTableTbody = function (option) {

    var tbody = option.thead;
    var html = "<tbody><tr ng-repeat='x in tablelist'>";
    $(tbody).each(function (index, item) {
        html += "<td>{{x." + item.value+ "}}</td>"

    })

 
    html += "</tr></tbody>";
 

    $("#GHPTABLE table").append(html);
}

var LoadTableTop = function (option) {

    var html = "<div class='row wrapper' >";
    html +="<div class='col-sm-5 m-b-xs' id='buttondiv'>"
 
    var topbutton = option.topbutton;
 
    $(topbutton).each(function (index,item) {
        html += "<button class=" + item.class + ">" + item.name + "</button>&nbsp;&nbsp;";
    })

    html += "</div></div>";
 
    $(".ghptabletop").append(html);

    var Searchhtml = ' <div class="col-sm-3">';
    Searchhtml += ' <div class="input-group">'
    Searchhtml += ' <input type="text" class="input-sm form-control" placeholder="Search">'
    Searchhtml += ' <span class="input-group-btn">'
    Searchhtml += '  <button class="btn btn-sm btn-default" type="button">Go!</button>'
    Searchhtml += ' </span>'
    Searchhtml += ' </div>'
    Searchhtml += ' </div>'
    Searchhtml += ' </div>'

}


var app = angular.module('GHPAPP', []);
app.controller('GHPTable', function ($scope, $http) {


    $scope.LoadData = function (option) {
 
        $http({
            method: 'POST',
            url: option.jsondataurl,
            data: { pageIndex: option.pageindex, pageSize:option.pagesnum}
        }).then(function successCallback(response) {
            if (response.data.start == 0) {
                $scope.tablelist = response.data.data;
              
            }
        }, function errorCallback(response) {
            // 请求失败执行代码
        });
    }
 
    $scope.LoadData(tableoption);
 
});