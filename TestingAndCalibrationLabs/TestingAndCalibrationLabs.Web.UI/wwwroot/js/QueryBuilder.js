

/// Entities content dropdown  hide or unhide function

function DropdownContent(HiddenValue) {

    var HiddenValue = "flush-" + HiddenValue;
    var element = document.getElementById(HiddenValue);

    if (element.style.display == "none") {
        element.style = "display:block";

    }
    else {
        element.style = "display:none";
    }


}


/// This Function is to Check  the Dropdown Item of Entities

function FunctionBox(TableName, CountValue) {

    var value = document.getElementById(TableName);



    for (var item = 0; item < CountValue; item++) {
        var element = TableName + item;



        if (value.checked == true) {
            document.getElementById(element).checked = true;
        }

        else {
            document.getElementById(element).checked = false;

        }


    }
}



/// This funtion will hiden and Unhide the icon of entities dropdown
$(".eqjs-ep-entity-node-button").click(function () {


    $(this).toggleClass(" eqjs-ep-entity-node-button-open");
});


/// This will clear the Select Checkboxes and its item

$(".eqjs-ep-tool-panel-deselect-all").click(function () {
    $(':checkbox').each(function () {
        this.checked = false;
    });

})



/// Checked will be selected  and will  put it in the express and title
function CheckboxContent() {

    var checkboxes = document.querySelectorAll('input[type=checkbox]:checked');

    var Description = document.getElementById("ColumnData");

    var Joinelement = document.getElementById('JoinTableinfo');
    var TableName = document.getElementById('TableName');
    var JOinColumn1 = document.getElementById('ColumnDropDown');
    var JoinColumn2 = document.getElementById('ColumnDropdown2');

    for (var item of checkboxes) {
       // 
        var Element = document.getElementById(item.id);

        if (Element.className == "child-item") {

            ///THis is for JOinPart
            const Option1 = document.createElement('option');
            Option1.value = Element.name+"."+Element.value;
            Option1.text =  Element.value;
            JOinColumn1.appendChild(Option1);
            const Option2 = document.createElement('option');
            Option2.value = Element.name + "." + Element.value;
            Option2.text =  Element.value;
            JoinColumn2.appendChild(Option2);
             
            ///JoinPartOVer

            var ElementAttribute = document.createElement('div');
            ElementAttribute.className = "eqjs-qc-row eqjs-qc-row-column-entattr";
            ElementAttribute.id = item.id + "column-menu";

            var sortingIcon = document.createElement('div');
            sortingIcon.className = "fa fa-sort-amount-asc";
            sortingIcon.style = "font-size:20px";
            sortingIcon.onclick = function () { Sorting(this) }
            sortingIcon.title = "sorting";
            sortingIcon.tabIndex = "0";
            ElementAttribute.appendChild(sortingIcon);

            var ExpressionColumn = document.createElement('div');
            ExpressionColumn.className = "eqjs-qc-expr-block";
            var ExpressionDiv = document.createElement('div');
            ExpressionDiv.className = "eqjs-qc-colelement eqjs-qc-attrelement";
            ExpressionDiv.innerHTML = "<a href='#'>" + Element.name + " " + Element.value + "</a>";
            ExpressionColumn.appendChild(ExpressionDiv);
            ElementAttribute.appendChild(ExpressionColumn);
         
            var TitleColumn = document.createElement('div');
            TitleColumn.className = "eqjs-qc-colelement eqjs-qc-captionelement";

            TitleColumn.innerHTML = "<a href='#' onclick='TitleEdit(this)' style title=" + Element.value + ">" + Element.value + "</a>" + '<input style="min-width: 0px; display: none;" value=' + Element.value + '></input> ';

            ElementAttribute.appendChild(TitleColumn);

            Description.appendChild(ElementAttribute);
            /// From here all icon data
            var sideIcon = document.createElement('div');
            sideIcon.className = "eqjs-column-buttonsBlock eqjs-qc-buttonsBlock";
            sideIcon.style.display = "block";

            var Aggregate = document.createElement('div');
            Aggregate.className = "eqjs-button-placeholder";
            Aggregate.id = ElementAttribute.id + "-agg";
            Aggregate.onclick = function () { Aggregates(this.id) }

            Aggregate.innerHTML = ' <i class="fa fa-facebook-f" style="font-size:10px;margin:2.5px" > </i>';
            sideIcon.appendChild(Aggregate);
            //Delete icon
            var Delete = document.createElement('div');
            Delete.className = "eqjs-button-placeholder";
            Delete.id = ElementAttribute.id;
            Delete.onclick = function () { DeleteExpression(this.id) }
            Delete.innerHTML = '<i class="fa fa-close"></i>'
            sideIcon.appendChild(Delete);
            ElementAttribute.appendChild(sideIcon);



        }

        else if(item.className="Parent-item") {
           
            const Option = document.createElement('option');
            Option.value =item.defaultValue;
            Option.text = item.defaultValue;

            
            TableName.appendChild(Option);
            const Option1 = document.createElement('option');
            Option1.value = item.defaultValue;
            Option1.text = item.defaultValue;
            Joinelement.appendChild(Option1);


        }
    }
    $(':checkbox').each(function () {
        this.checked = false;
    });
    document.getElementById('JOINDIV').style.display = "block";
   }


/// This will delete the single Expression
function DeleteExpression(ID) {

    document.getElementById(ID).remove();
    var Expression = document.getElementsByClassName("eqjs-menu-rootLevel eqjs-menu-levelDiv")[0]
    Expression.style.display = "none";

}

var temporaryDetail = null;
var sortingIconCaller = null;

// sorting function
function Sorting(sortIconDetails) {
    var stylevalue = sortIconDetails.getBoundingClientRect();

    var sortDropdown = document.getElementById('ColumnsPanel-SortMenu');
    sortDropdown.style.display = "block";
    sortDropdown.style.top = stylevalue.bottom + "px";
    sortDropdown.style.left = stylevalue.left + "px";
    sortingIconCaller = sortIconDetails;
}

/// Dropdown item For Aggregate function

function Aggregates(Aggregitem) {

    var styleData = document.getElementById(Aggregitem);
    var data = $(styleData.parentElement.parentElement).find('.eqjs-qc-expr-block')[0];
    if (data.nextSibling.children.length > 2) {
        while (data.children.length != 1) {
            $(data.children[0]).remove();
        }
        $(data).children().show();
        while (data.nextSibling.children.length != 2) {
            $(data.nextSibling.children[0]).remove();
        }

        $(data.nextSibling.children[0]).show();

    }
    else if (data.children.length > 1) {

        var TitleTag = $(data).find('.eqjs-qc-colelement.eqjs-qc-aggrfuncelement')[0].innerText;

        while (data.children.length != 1) {
            $(data.children[0]).remove();

        }

        Titledetail = (data.nextSibling.children[0]);

        Titledetail.innerText = (Titledetail.innerText).split(TitleTag).join("");
        Titledetail.title = Titledetail.innerText;
        TitleTag = (data.nextSibling.children[1]);
        TitleTag.value = Titledetail.innerText;

    }
    else {

        var aggreg = document.getElementsByClassName("eqjs-menu-rootLevel eqjs-menu-levelDiv")[0]
        aggreg.style.display = "none";


        var arr = ["COUNT", "CNTDST", "MIN", "MAX", "CustomSqlDivider", "CUSTOMSQL"];




        var rect = styleData.getBoundingClientRect();

        var aggreg = document.getElementsByClassName("eqjs-menu-rootLevel eqjs-menu-levelDiv")[0]
        aggreg.style.display = "block";
        //aggreg.id = Aggregitem + "-menu";
        aggreg.style.top = (rect.bottom + 5) + "px";
        aggreg.style.left = (rect.left + 2) + "px";



        ///for Dropdown item of aggregate function
        var parent = document.getElementsByClassName('eqjs-menu-scrollDiv')[0]

        for (var item = 0; item < parent.children.length; item++) {
            // alert(parent.children[item]);
            parent.children[item].id = Aggregitem + "-" + arr[item];
        }
        sortingIconCaller = Aggregitem;

    }

}


var MenuDetail;
var ConditionValueData = null;
/// This is to hide all the Menu items
window.onclick = function (event) {

    if (event.target.className != "ScrollItemJoin" && event.target.className != "JoinMenu" && event.target.className != "eqjs-qp-condition-button eqjs-qp-condition-button-menu eqjs-qp-condition-button-active") {
        document.getElementById('JOIN-ADD-MENU').style.display = "none";
    }

    if (event.target.className != "fa fa-facebook-f") {
        var aggreg = document.getElementsByClassName("eqjs-menu-rootLevel eqjs-menu-levelDiv")[0]
        aggreg.style.display = "none";
    }
    if (event.target.className != "fa fa-sort-amount-asc") {
        var sortDropdown = document.getElementById('ColumnsPanel-SortMenu');
        sortDropdown.style.display = "none";
        // temporaryDetail = null;
    }
    if (event.target.localName != 'a') {
        var aggreg = document.getElementById("DataTypeMenu");
        aggreg.style.display = "none";
    }

    if (event.target.localName != 'a' && temporaryDetail != null && event.target.localName != 'input') {

        if (temporaryDetail.parentElement.children.length > 2) {


            var inputdata = temporaryDetail.nextSibling;
            temporaryDetail.title = inputdata.value;
            temporaryDetail.parentElement.previousElementSibling.children[0].children[0].innerHTML = inputdata.value;
            temporaryDetail.innerHTML = inputdata.value;
            inputdata.style.display = "none";
            temporaryDetail.style.display = "block";
            temporaryDetail = null;

        }
        else {
            var inputdata = temporaryDetail.nextSibling;
            temporaryDetail.title = inputdata.value;
            temporaryDetail.innerHTML = inputdata.value;
            inputdata.style.display = "none";
            temporaryDetail.style.display = "block";
            temporaryDetail = null;
        }

    }
    if (event.target.localName != 'a' && customTemporaryValue != null && event.target.localName != 'input') {

        var inputdata = customTemporaryValue.nextSibling;
        inputdata.style.display = "none";
        customTemporaryValue.style.display = "block";
        customTemporaryValue = null;

    }


    // For the condition Query Part Window onclick
    if (event.target.localName != 'a' && event.srcElement.className != 'eqjs-menu-itemDiv eqjs-menu-itemDiv-hasChildren') {

        document.getElementById('QueryPanel-LinkTypeMenu').style.display = "none";
        document.getElementById('QueryPanel-EntitiesMenu').style.display = "none";
        document.getElementById('QueryPanel-EntitiesMenu-children').style.display = "none";


    }
    if (MenuDetail != null && event.target.localName != 'a') {

        document.getElementById('Query-Dropdown').style.display = "none";
        MenuDetail = null;
    }

    if (event.target.localName != 'a' && ConditionValueData != null && event.target.localName != 'input') {


        var inputdata = ConditionValueData.nextSibling;
        inputdata.style.display = "none";
        ConditionValueData.style.display = "block";
        if (inputdata.value != "") {
            ConditionValueData.innerHTML = inputdata.value;
            ConditionValueData.title = inputdata.value;
        }

        ConditionValueData = null;

    }

    if (event.srcElement.className != 'eqjs-qp-condition-button eqjs-qp-condition-button-menu eqjs-qp-condition-button-active' && event.target.localName != 'a') {
        document.getElementById('QueryPanel-ConditionMenu').style.display = "none"
    }
}


///This will edit the title on click
function TitleEdit(titledetail) {

    temporaryDetail = titledetail;
    titledetail.style.display = "none";
    var inputdata = titledetail.nextSibling;
    inputdata.style.display = "block";
    titledetail.innerHTML = titledetail.title;


}

var customTemporaryValue = null;

/// This will make change for CustomFunction

function CustomFunction(titledetail) {
    customTemporaryValue = titledetail;
    titledetail.style.display = "none";
    var inputdata = titledetail.nextSibling;
    inputdata.style.display = "block";


}

/// This will change the arrangement of Expression item as per Selected Order

function ExpressionPositioning(Position) {
    var cont = $(".eqjs-qc-columns");
    var arr = $.makeArray(cont.children());
    var temp = arr;

    switch (Position) {

        case 1:
            arr.sort(function (a, b) {


                var textA = a.textContent;
                var textB = b.textContent;


                if (textA < textB) return -1;
                if (textA > textB) return 1;

                return 0;
            });
            cont.empty();

            $.each(arr, function () {
                cont.append(this);
            });
            break;

        case 2:
            arr.sort(function (a, b) {


                var textA = a.textContent;
                var textB = b.textContent;


                if (textA > textB) return -1;
                if (textA < textB) return 1;

                return 0;
            });
            cont.empty();

            $.each(arr, function () {
                cont.append(this);
            });
            break;
        case 3:
            $(".eqjs-qc-columns").prepend(sortingIconCaller.parentElement);
            break;
        case 4:
            $(sortingIconCaller.parentElement).insertBefore($(sortingIconCaller.parentElement.previousSibling));
            break;
        case 5:

            $(sortingIconCaller.parentElement).next().after($(sortingIconCaller.parentElement));
            break;
        case 6:
            $(".eqjs-qc-columns").append(sortingIconCaller.parentElement);
            break;


        default:

    }
}


/// Dropdown List for the Custom function  string

function customStringDropdown(ElementValue) {
    temporaryDetail = ElementValue;
    var stringPosition = ElementValue.getBoundingClientRect();
    var Aggregates = document.getElementById("DataTypeMenu");
    Aggregates.style.display = "block";
    Aggregates.style.top = (stringPosition.bottom + 5) + "px";
    Aggregates.style.left = (stringPosition.left + 2) + "px";
}


/// This  function is  to add all the items  of aggregate function  to the expression
function AggregateFunctionAdd(Position) {

    var element = document.getElementById(sortingIconCaller).offsetParent.offsetParent.children[2];

    var count = document.createElement('div');

    count.className = "eqjs-qc-colelement eqjs-qc-aggrfuncelement";


    /// for of element creation
    var spanclass = document.createElement('span');
    spanclass.className = "eqjs-qc-colelement";
    spanclass.title = "of";
    spanclass.innerHTML = spanclass.title;


    switch (Position) {

        case 1:

            count.innerHTML = '<a href="#" onclick="Aggregates(this)">Count</a>';
            $(element).prepend($(spanclass));
            $(element).prepend($(count));
            element = element.nextSibling.firstChild;
            element.title += " Count";
            element.innerHTML += " Count";
            element.nextSibling.value += " Count";

            break;


        case 2:
            count.innerHTML = '<a href="#" onclick="Aggregates(this)">Distinct count</a>';
            $(element).prepend($(spanclass));
            $(element).prepend($(count));
            element = element.nextSibling.firstChild;
            element.title += " Distinct count";
            element.innerHTML += " Distinct count";
            element.nextSibling.value += " Distinct count";


            break;

        case 3:
            count.innerHTML = "<a href='#' onclick='Aggregates(this)'>Minimum</a>";
            $(element).prepend($(spanclass));
            $(element).prepend($(count));
            element = element.nextSibling.firstChild;

            element.title += " Minimum";
            element.innerHTML += " Minimum";
            element.nextSibling.value += " Minimum";


            break;

        case 4:
            count.innerHTML = '<a href="#" onclick="Aggregates(this)">Maximum</a>';
            $(element).prepend($(spanclass));
            $(element).prepend($(count));
            element = element.nextSibling.firstChild;

            element.title += " Maximum";
            element.innerHTML += " Maximum";
            element.nextSibling.value += " Maximum";
            break;

        case 5:

            var divCont = document.createElement('div');
            divCont.className = "eqjs-qc-colelement eqjs-qc-attrelement";
            divCont.innerHTML = '<a href="#" title="Custom SQL Column" onclick="CustomFunction(this)">Custom SQL Column</a>' + '<input style="width:100%; display:none;" value=' + element.innerText + '>'


            var divCont2 = document.createElement('div');
            divCont2.className = "eqjs-qc-colelement";
            divCont2.innerHTML = "<span title=': ' >: </span>"


            var divCont3 = document.createElement('div');
            divCont3.className = "eqjs-qc-colelement eqjs-qc-attrelement";
            divCont3.innerHTML = '<a href="#" title="String" onclick="customStringDropdown(this)"> String</a>'

            $(element).children().hide();


            var anchorTag = '<a href="#" onclick="TitleEdit(this)" title="Custom SQL Column" >Custom SQL Column </a>'

            var inputTag = document.createElement('input');
            inputTag.value = "Custom SQL Column";
            inputTag.style = "display:none";




            $(element).prepend($(divCont3));
            $(element).prepend($(divCont2));
            $(element).prepend($(divCont));

            element = element.nextSibling;
            $(element).children().hide();
            $(element).prepend($(inputTag));
            $(element).prepend($(anchorTag));

            break;

        default:
    }

}


/// This function is to  replace the string with the selected item

function DataTypeMenuFunc(DatatypeValue) {

    temporaryDetail.innerHTML = DatatypeValue.innerText;

}

//// From Here Javascript is written for condition Block



//// This function Will show the Where select Type Menu
function ConditionAll(Value) {
    var PositionDetails = Value.getBoundingClientRect();
    document.getElementById('QueryPanel-LinkTypeMenu').style.display = "block";
    document.getElementById('QueryPanel-LinkTypeMenu').style.top = (PositionDetails.bottom + 3) + "px";
    document.getElementById('QueryPanel-LinkTypeMenu').style.left = (PositionDetails.left + 5) + "px";

}


//// This function will change the value of where Condition 
function ConditionADD(Value) {

    document.getElementById('conditionValue').innerHTML = Value.innerText;
}

//// It will show the Dropdown on click of New Condition Menu
function NewConditionMenu(Position) {

    var PositionDetails = Position.getBoundingClientRect();
    document.getElementById('QueryPanel-EntitiesMenu').style.display = "block";
    document.getElementById('QueryPanel-EntitiesMenu').style.top = (PositionDetails.bottom + 3) + "px";
    document.getElementById('QueryPanel-EntitiesMenu').style.left = (PositionDetails.left + 5) + "px";


}

//// This Function will Load the Data for New Condition
window.onload = function () {

    // 
    for (var item = 0; item < Key.length; item++) {
        var ChildrenDiv = document.createElement('div');
        ChildrenDiv.className = "eqjs-menu-itemDiv eqjs-menu-itemDiv-hasChildren";
        ChildrenDiv.innerHTML = Key[item].tableName;
        ChildrenDiv.onclick = function () { ConditionChildMenu(this) }
        var childSpan = document.createElement('span');
        childSpan.className = "eqjs-menu-itemDiv-arrow";
        childSpan.innerHTML = "&gt;";

        ChildrenDiv.appendChild(childSpan);

        var element = document.getElementById('QueryPanel-EntitiesMenu').children[0];


        element.appendChild(ChildrenDiv);
        element.appendChild(ChildrenDiv);
    }
}

//// This will show the list of childrens of Child Menu of New Condition
function ConditionChildMenu(itemvalue) {
    valueDetail = itemvalue.innerText;
    valueDetail = valueDetail.replace("\n>", "");
    //var Key = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model.FieldValues.Keys));
    //var KeyValues = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model.FieldValues.Values));
    var element = document.getElementById('QueryPanel-EntitiesMenu-children');
    element.style.display = "block";
    element = element.children[0];
    element.innerHTML = "";
    for (var item = 0; item < Key.length; item++) {

        if (valueDetail == Key[item].tableName) {
            for (var value = 0; value < KeyValues[item].length; value++) {

                var ChildrenDiv = document.createElement('div');
                ChildrenDiv.className = "eqjs-menu-itemDiv";
                ChildrenDiv.onclick = function () { ConditionDetails(valueDetail, this) }
                ChildrenDiv.innerHTML = KeyValues[item][value].coloumnName;
                element.appendChild(ChildrenDiv);

            }
            var PositionDetails = itemvalue.getBoundingClientRect();
            document.getElementById('QueryPanel-EntitiesMenu-children').style.display = "block";
            document.getElementById('QueryPanel-EntitiesMenu-children').style.top = (PositionDetails.top + 3) + "px";
            document.getElementById('QueryPanel-EntitiesMenu-children').style.left = (PositionDetails.right + 5) + "px";

            break;
        }

    }
}

//// it will add the Condition as per the selection in the New Condition Menu
function ConditionDetails(ValueDetail, Innertext) {


    var detail = document.getElementById('condition-data');


    var ParentDiv = document.createElement('div');
    ParentDiv.className = "eqjs-qp-row eqjs-qp-row-condition eqjs-qp-level-1";

    if (detail.children.length >= 1) {
        var conditionAnd = document.createElement('span')
        conditionAnd.className = "eqjs-qp-condelement eqjs-qp-condition-conjuction";
        conditionAnd.title = "and";
        conditionAnd.innerHTML = "and";
        ParentDiv.appendChild(conditionAnd);
    }



    var FirstConditionElement = document.createElement('div')
    FirstConditionElement.className = "eqjs-qp-condelement eqjs-qp-attrelement";


    var ConditionElement1 = '<a href="javascript:void(0)" title=' + ValueDetail + ' ' + Innertext.innerText + '>' + ValueDetail + ' ' + Innertext.innerText + '</a>'
    FirstConditionElement.innerHTML = ConditionElement1;



    var MidElement = document.createElement('div')
    MidElement.className = "eqjs-qp-condelement eqjs-qp-operelement";
    MidElement.innerHTML = '<a href = "javascript:void(0)" title ="starts with"onclick="QueryConditionMenu(this)">starts with</a>';

    var LastElement = document.createElement('div')
    LastElement.className = "eqjs-qp-condelement"
    LastElement.innerHTML = '<a href="javascript:void(0)"onclick="ConditionValueEdit(this)" title = "[enter value]" > [enter value] </a><input class="eqjs-qp-ve-editbox" type="text" style="display: none;min-width:0px">'


    var ButtonBlock = document.createElement('div')
    ButtonBlock.className = "eqjs-qp-condition-buttonsBlock";
    ButtonBlock.style.display = "block"
    ButtonBlock.innerHTML = '<div class="eqjs-qp-button-placeholder"><div class="eqjs-qp-condition-button eqjs-qp-condition-button-menu eqjs-qp-condition-button-active" onclick="ButtonBlock(this)" tabindex = "0"title = "Show menu" ></div></div >'

    ParentDiv.appendChild(FirstConditionElement);
    ParentDiv.appendChild(MidElement);
    ParentDiv.appendChild(LastElement);
    ParentDiv.appendChild(ButtonBlock);

    detail.appendChild(ParentDiv);

}


//// This function will make change in the condition menu
function ConditionValueEdit(Value) {
    ConditionValueData = Value;
    Value.style.display = "none";
    var inputdata = Value.nextSibling;
    inputdata.style.display = "block";
}


var ParentElementDiv = null;

//// this function will show the button block menu
function ButtonBlock(Data) {
    ParentElementDiv = Data.parentElement.parentElement.parentElement;
    var stringPosition = Data.getBoundingClientRect();
    var Aggregates = document.getElementById('QueryPanel-ConditionMenu')
    Aggregates.style.display = "block";
    Aggregates.style.top = (stringPosition.bottom + 5) + "px";
    Aggregates.style.left = (stringPosition.left + 2) + "px";
}

//// This will perform the action as per the selected value in the ButtonBlock Menu
function ButtonBlockMenufunction(Position) {

    switch (Position) {
        case 1:

        case 2:
           
            $(ParentElementDiv).remove();
            ParentElementDiv = null;
            break;
        case 3:
            break;
        case 4:
            break;

        default:


    }
}

//// This will show the
function QueryConditionMenu(Menu) {

    var QueryDropdown = document.getElementById('Query-Dropdown');
    QueryDropdown.style.display = "block"

    MenuDetail = Menu;
    var stringPosition = Menu.getBoundingClientRect();

    QueryDropdown.style.top = (stringPosition.bottom + 5) + "px";
    QueryDropdown.style.left = (stringPosition.left + 2) + "px";


}

function QueryCondition(ConditionValue) {
    MenuDetail.innerHTML = ConditionValue;

}