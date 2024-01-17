function SideBarOpen(value) {

    var controlSidebar1 = document.getElementById('control-sidebar-1');
    var controlSidebar2 = document.getElementById('RightSideMenuAside');

    if (value === "control-sidebar-1") {
        controlSidebar2.classList.add('control-sidebar-hidden');
        controlSidebar1.classList.remove('control-sidebar-hidden');
    } else {
        controlSidebar1.classList.add('control-sidebar-hidden');
        controlSidebar2.classList.remove('control-sidebar-hidden');
    }

};



$('.icp-auto').iconpicker();

$(document).ready(function () {

    document.getElementById('RightSideMenuAside').className = "control-sidebar control";

    var PageNavigationData = [];
    function createTopNavItem(item) {
        var dropdownCode = `  <li class="nav-item dropdown"><a class="nav-link" data-toggle="dropdown" href="#"><i class="${item.iconName} nav-icon"style="font-size:15px;"></i></a>  <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">`;

        if (item.childrens) {
            var code = createTopNavMenu(item.childrens);
            dropdownCode += code;
        }
        dropdownCode += "</li>";
        return dropdownCode;
    }

    function createTopNavMenu(menuItems) {
        let htmlCode = '';
        menuItems.forEach(item => {
            htmlCode += `<a href="${item.url}"class="dropdown-item"><i class="${item.iconName}  nav-icon"></i>  ${item.moduleName} </a> <div class="dropdown-divider"></div> `;
        });
        htmlCode += '</div>';
        return htmlCode;
    }

    function createNavBottomItem(item) {
        var dropdownCode = `<li><a  href="#"  class="feat-btn" onclick="showdropdown(this)"><i class="${item.iconName}"></i> ${item.name}<span class="fas fa-caret-down "></span></a>`;
        if (item.childrens) {
            var code = createBottomNavMenu(item.childrens);
            dropdownCode += code;
        }
        dropdownCode += "</li>";
        return dropdownCode;
    }

    function createBottomNavMenu(menuItems) {
        let htmlCode = '<ul class="feat-show">';
        menuItems.forEach(item => {
            htmlCode += `<li><a href="${item.url}"><i class="${item.iconName}"></i> ${item.moduleName}</a></li>`;
        });
        htmlCode += '</ul>';
        return htmlCode;
    }
    function createNavItem(item) {
        var dropdownCode = `   <li class="nav-item"><a href="#" class="nav-link active" ><i class="${item.iconName} nav-icon"></i><p> ${item.name}<i class="right fas fa-angle-left "></i></p></a>`;
        if (item.childrens) {
            var code = createNavMenu(item.childrens);
            dropdownCode += code;
        }
        dropdownCode += "</li>";
        return dropdownCode;
    }

    function createNavMenu(menuItems) {
        let htmlCode = '<ul class="nav nav-treeview">';
        menuItems.forEach(item => {
            htmlCode += `<li class="nav-item" ><a href="${item.url}"class="nav-link "><i class="${item.iconName}  nav-icon"></i><p>  ${item.moduleName}</p> </a>  </li>`;
        });
        htmlCode += '</ul>';
        return htmlCode;
    }
    function renderNavigation() {
        const dynamicNavContainer = $("#SideBar-ContentDropdown");
        const dynamicRightSideNavbar = $("#RightNavMenu");
        const dynamicTopNavbar = $("#TopNavItem");
        const dynamicBottomNavContainer = $("#dynamicBottomContainer");
        PageNavigationData.forEach((item) => {
            if (item.navigationTypes === 1025) {
                dynamicNavContainer.append(createNavItem(item));
            }
            if (item.navigationTypes === 1024) {
                dynamicRightSideNavbar.append(createNavItem(item));
            }
            if (item.navigationTypes === 1022) {
                dynamicTopNavbar.prepend(createTopNavItem(item));
            }
            if (item.navigationTypes === 1023) {
                dynamicBottomNavContainer.append(createNavBottomItem(item));
            }
        });
    }

    $.ajax({
        type: "POST",
        url: "/UiPageNavigation/GetAllPagesWithNavigation",
        success: function (response) {
            response.sort(function (a, b) {
                if (a.orders < b.orders) { return 1; }
                if (a.orders > b.orders) { return -1; }
                return 0;
            });

            PageNavigationData = response;
            renderNavigation();
        },
        error: function (req, status, error) {
            console.log(req);
            console.log(status);
            console.log(error);
        }
    });
});