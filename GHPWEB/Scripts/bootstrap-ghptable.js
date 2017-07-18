


var LoadTable = function (option) {
    LoadTableThead(option)
    LoadTableTbody(option)
 
      }
var LoadTableThead = function (option) {

 

    var thead = option.thead;

    var html = "<thead><tr>";
    $(thead).each(function (index, item) {

        if (item.IsChack) {
            html += '<th>';
            html += '<label class="checkbox m-n i-checks"><input type="checkbox" class="checkboxAll" ng-model="all"  ng-click="ChangeCheck(\'All\')"><i></i></label>';
            html += '</th>';
        } else {

            html += "<th>" + item.name + "</th>"
        }

    })



    html += "</tr></thead>";

    $("#GHPTABLE table").append(html);

}
var LoadTableTbody = function (option) {

    var tbody = option.thead;
    var html = "<tbody><tr ng-repeat='x in tablelist'>";
    $(tbody).each(function (index, item) {

        if (item.IsChack) {
 
            html += '<td>';
            html += '<label class="checkbox m-n i-checks"><input type="checkbox" ng-checked="all" name="' + item.value + '" value="{{x.' + item.value + '}}"  ng-click="ChangeCheck()"><i></i></label>';
            html += '</td>';
        } else {

            html += "<td>{{x." + item.value + "}}</td>"
        }
    })

 
    html += "</tr></tbody>";
 

    $("#GHPTABLE table").append(html);
}

 
 
 