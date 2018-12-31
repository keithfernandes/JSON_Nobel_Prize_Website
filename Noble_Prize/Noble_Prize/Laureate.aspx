<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laureate.aspx.cs" Inherits="Noble_Prize.Laureate" %>

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
            $("#txtCountry").autocomplete({
                source: "AutoCompleteCountries.aspx",
            });
        });
    </script>
    <title>Nobel Winners | Search</title>
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
        <h2>Laureates</h2>
        <form id="form1" runat="server">
            Enter Year     
            <asp:TextBox ID="txtyear" runat="server" OnTextChanged="txtyear_TextChanged" Width="76px" Height="24px"></asp:TextBox>
            &nbsp;Country
            <asp:TextBox ID="txtCountry" runat="server" Width="129px" OnTextChanged="txtCountry_TextChanged" Height="24px" />
            &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" BackColor="Indigo" Font-Names="Courier New" ForeColor="White" Height="40px" Width="114px" />
        </form>
        <%
            // execute below process only when search complete and all columns are not blank
            if (SearchCompleted1
                &&
                !(
                    (String.IsNullOrWhiteSpace(txtyear.Text) || String.IsNullOrEmpty(txtyear.Text))
                     &&
                    (String.IsNullOrWhiteSpace(txtCountry.Text) || String.IsNullOrEmpty(txtCountry.Text))
                )
               )
            {
                // first iterate to check if there are any records matching the input given, so that
                // just blank table headers are not displayed in the output
                int count = 0;
                foreach (var cod in Laureatecollection.Laureates)
                {
                    String country = cod.Borncountry;
                    foreach (var codinner in cod.Prizes)
                    {
                        if (IsDoubleInput)
                        {
                            if (!String.IsNullOrEmpty(country))
                            {
                                Check = codinner.Year == DateFilter && country.ToLower().Contains(txtCountry.Text.ToLower());
                            }
                        }
                        else
                        {
                            if (String.IsNullOrWhiteSpace(txtyear.Text) || String.IsNullOrEmpty(txtyear.Text))
                            {
                                if (!String.IsNullOrEmpty(country))
                                {
                                    Check = country.ToLower().Contains(txtCountry.Text.ToLower());
                                }
                            }
                            else
                            {
                                Check = codinner.Year == DateFilter;
                            }
                        }
                        if (Check)
                        {
                            count++;
                        }
                    }
                }
                // Execute below code to display table, only when we have found a count of filtered records > 1
                if (count > 1)
                {
        %>
        <table>
            <thead>
                <tr>
                    <th>Year</th>
                    <th>Category</th>
                    <th>First Name</th>
                    <th>Surname</th>
                    <th>Gender</th>
                    <th>Birth Date</th>
                    <th>Country of Birth</th>
                    <th>Born City</th>
                    <th>Motivation</th>
                </tr>
            </thead>
            <tbody>
                <%  foreach (var cod in Laureatecollection.Laureates)
                    {
                        String country = cod.Borncountry;
                %>
                <%  foreach (var codinner in cod.Prizes)
                    {%>
                <%  if (IsDoubleInput)
                    {
                        if (!String.IsNullOrEmpty(country))
                        {
                            Check = codinner.Year == DateFilter && country.ToLower().Contains(txtCountry.Text.ToLower());
                        }
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(txtyear.Text) || String.IsNullOrEmpty(txtyear.Text))
                        {
                            if (!String.IsNullOrEmpty(country))
                            {
                                Check = country.ToLower().Contains(txtCountry.Text.ToLower());
                            }
                        }
                        else
                        {
                            Check = codinner.Year == DateFilter;
                        }
                    }
                %>
                <%  if (Check)
                    { %>
                <tr>
                    <td><%=codinner.Year %></td>
                    <td><%=codinner.Category %></td>
                    <td><%=cod.Firstname %></td>
                    <td><%=cod.Surname %></td>
                    <td><%=cod.Gender %></td>
                    <td><%=cod.Born %></td>
                    <td><%=cod.Borncountry %></td>
                    <td><%=cod.Borncity%></td>
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
                <%
                                    Check = false;
                                }
                            }
                        }
                    }
                    else
                    {%><p>No Results Found :(</p>
                <%}
                    }
                    else
                    {
                        if (SearchCompleted1)
                        {%><p>Enter a valid input !</p>
                <%  }
                    }
                %>
            </tbody>
        </table>
    </div>
</body>
</html>
