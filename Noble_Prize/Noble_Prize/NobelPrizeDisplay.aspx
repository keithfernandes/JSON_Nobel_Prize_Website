<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NobelPrizeDisplay.aspx.cs" Inherits="Noble_Prize.NobelPrizeDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" media="screen" href="Style_Sheets/Web.css" type="text/css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
        $(function () {
            $("#txtYear").autocomplete({
                source: "AutoCompleteCategories.aspx",
            });
        });
    </script>
    <title>Nobel Winner | Search</title>
</head>

<body>
    <div class="title">
        <img src="Images/Icon.png" alt="Nobel icon image" id="nobel" />
        <h1>Nobel Winners</h1>
    </div>
    <div class="menu">
        <button class="dropdown">Hover Here</button>
        <div class="dropdown_content">
            <a href="Home.html">Home</a>
            <a href="NobelPrizeDisplay.aspx">Nobel Prize</a>
            <a href="Laureate.aspx">Laureates</a>
        </div>
    </div>
    <div class="content">
        <h2>Nobel Winners</h2>
        <form id="form1" runat="server">
            Enter Category or Year
            <asp:TextBox ID="txtYear" runat="server" AutoCompleteType="Disabled" Height="24px"></asp:TextBox>
            &nbsp;<asp:Button ID="txtSearch" runat="server" Text="Search" OnClick="Button1_Click" BackColor="Indigo" Font-Bold="False" Font-Italic="False" Font-Names="Courier New" Font-Size="Medium" ForeColor="White" BorderStyle="None" Height="40px" Style="margin-top: 4px" Width="106px" />
        </form>
        <%
            // execute below process only when search complete and all columns are not blank
            if (SearchCompleted1 && txtYear.Text != "" && !String.IsNullOrWhiteSpace(txtYear.Text) && !String.IsNullOrEmpty(txtYear.Text))
            {
                // first iterate to check if there are any records matching the input given, so that
                // just blank table headers are not displayed in the output
                int resultCount = 0;

                foreach (var cod in Nobelprizecollection.Prizes)
                {
                    if (IsDoubleInput)
                    {
                        Check = cod.Year == DateFilter && cod.Category.Contains(WordPart.ToLower());
                    }
                    else
                    {
                        Check = cod.Year == DateFilter || cod.Category.Contains(WordPart.ToLower());
                    }
                    if (Check)
                    {
                        resultCount++;
                    }

                }
                // Execute below code to display table, only when we have found a count of filtered records > 1
                if (resultCount > 0)
                {
        %>
        <br />
        <br />
        <table>
            <thead>
                <tr>
                    <th>Year</th>
                    <th>Category</th>
                    <th>Firstname/Organization</th>
                    <th>Lastname</th>
                    <th>Motivation</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var cod in Nobelprizecollection.Prizes)
                    { %>
                <% if (IsDoubleInput)
                    {
                        Check = cod.Year == DateFilter && cod.Category.Contains(WordPart.ToLower());
                    }
                    else
                    {
                        Check = cod.Year == DateFilter || cod.Category.Contains(WordPart.ToLower());
                    }
                %>                <% if (Check)
                                      { %>
                <tr>
                    <td><%=cod.Year %></td>
                    <td><%=cod.Category %></td>
                    <td></td>
                    <td></td>

                </tr>
                <tr>
                    <%foreach (var codinner in cod.Laureates)
                        { %>
                    <td></td>
                    <td></td>
                    <td><%=codinner.Firstname %></td>
                    <td><%=codinner.Surname %></td>
                    <%if (!String.IsNullOrEmpty(codinner.Motivation) && !String.IsNullOrWhiteSpace(codinner.Motivation))
                        { %>
                    <td><%=codinner.Motivation.Trim('"')%></td>
                    <% }
                        else
                        { %>
                    <td>No Data found</td>
                    <%}
                    %>
                </tr>
                <%   } %>                <%   } %>                <%} %>
            </tbody>
        </table>
        <% }
            else
            {
        %>
        <p>Sorry, No Results found :(</p>
        <%   }
            }
            else
            {
                if (SearchCompleted1)
                {%>
        <p>Please enter a valid input!</p>
        <% 
                }
            }
        %>
    </div>
</body>
</html>
