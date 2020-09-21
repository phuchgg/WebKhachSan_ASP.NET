<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="HaLongParadise.Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="/css/jquery-ui.css" rel="stylesheet" />
    <script type='text/javascript' src="/scripts/jquery-ui.js"></script>
    <style>
        .textright {
            text-align: right;
        }

        .textleft {
            text-align: left;
            padding-left: 5px;
        }

        .color {
            color: white;
            background-color: #f6bd22;
        }

        table {
            width: 850px;
            margin: 30px;
            /*border: 5px solid #008089;*/
        }

        td {
            line-height: 30px;
        }

        .textbox {
            width: 150px;
            height: 22px;
        }
    </style>
    <script>
        jQuery(function () {
            $("#<%= txtFrom.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtTo.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">

</asp:ScriptManager>
    <%--content--%>
    <div class="main">
        <div class="content">
             
            <div class="title"><asp:Label ID="Label20" Text='<%$ Resources:Resource, DatPhong%>' runat="server" ></asp:Label></div>
            <asp:UpdatePanel runat="server" ID="upLoad">
                      <ContentTemplate>
            <table>
                
                <tr>
                    <td colspan="2"><asp:Label ID="Label4" Text='<%$ Resources:Resource, ThongBao%>' runat="server" ></asp:Label></td>
                </tr>
                <tr>
                      <td colspan="2"><asp:Label ID="lblNote" Font-Size="14px"  runat="server" ></asp:Label></td>
                </tr>
                <tr>
                    <th colspan="2" class="color textleft"><asp:Label ID="Label1" Text='<%$ Resources:Resource, ChiTietYeuCau%>' runat="server" ></asp:Label></th>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label2" Text='<%$ Resources:Resource, NgayDen%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <input runat="server" type="text" id="txtFrom" style="width:150px; height:22px"/></td>
                </tr
              
                <tr>
                     
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label3" Text='<%$ Resources:Resource, NgayDi%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <asp:TextBox runat="server" id="txtTo" CssClass="textbox" AutoPostBack="true" OnTextChanged="txtTo_TextChanged"/>
                    </td>
                    
                </tr
                   
                <tr>
                    <td class="textright"><asp:Label ID="Label5" Text='<%$ Resources:Resource, SoDem%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <asp:Label ID="lblLightCount" runat="server" ></asp:Label></td>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label6" Text='<%$ Resources:Resource, LoaiPhong%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <asp:DropDownList runat="server" ID="ddlRoom" Height="28px" Width="205px">
                          
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList runat="server" ID="ddlRoomType" Height="28px" Width="96px">
                                                    
                        </asp:DropDownList>

                    </td>
                </tr>
                <%--    <tr>
                    <td class="textright">Tinh trạng phòng</td>
                    <td class="textleft">----</td>
                </tr>
                <tr>
                    <td class="textright">Chi phí phòng</td>
                    <td class="textleft">----</td>
                </tr>--%>
                <tr>
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label7" Text='<%$ Resources:Resource, SoLuongKhach%>' runat="server" ></asp:Label></td>
                    <td class="textleft"><asp:Label ID="Label8" Text='<%$ Resources:Resource, NguoiLon%>' runat="server" ></asp:Label>
                    <input type="text" style="width:50px; height:22px" runat="server" id="txtParent" />
                       <asp:Label ID="Label9" Text='<%$ Resources:Resource, TreNho%>' runat="server" ></asp:Label>
                    <input type="text" style="width:50px; height:22px" runat="server" id="txtChildren" />
                    </td>
                </tr>
                <tr>
                    <td class="textright"><asp:Label ID="Label10" Text='<%$ Resources:Resource, GiuongPhu%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <input type="text" style="width: 66px; height:22px;" runat="server" id="txtBed" />
                    </td>
                </tr>
                <tr>
                    <td class="textright"><asp:Label ID="Label11" Text='<%$ Resources:Resource, YeuCauKhac%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <asp:TextBox runat="server" ID="txtRequest" TextMode="MultiLine" Height="111px" Width="401px" OnTextChanged="txtRequest_TextChanged" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <th colspan="2" class="color textleft"><asp:Label ID="Label19" Text='<%$ Resources:Resource, ThongTinKhachHang%>' runat="server" ></asp:Label></th>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label12" Text='<%$ Resources:Resource, HoTen%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <input runat="server" id="txtFullName" type="text" style="width:205px; height:22px" />

                    </td>
                </tr>
                <tr>
                    <td class="textright"><asp:Label ID="Label13" Text='<%$ Resources:Resource, CongTy%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <input runat="server" id="txtCompany" type="text" style="width:401px; height:22px" />
                    </td>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label14" Text='<%$ Resources:Resource, DiaChi%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <input runat="server" id="txtAddress" type="text" style="width:401px; height:22px" />
                    </td>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label15" Text='<%$ Resources:Resource, QuocGia%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                       <%-- <input runat="server" id="txtCountry" type="text" />--%>
                        <select runat="server" id="txtCountry" style="width:205px; height:28px" >
                                <option value="-1">--Select--</option>
                                <option value="Australia">Australia</option>
                                <option value="Austria">Austria</option>
                                <option value="Belgium">Belgium</option>
                                <option value="Bolivia">Bolivia</option>
                                <option value="Bosnia and Herzegovina">Bosnia and Herzegovina</option>
                                <option value="Botswana">Botswana</option>
                                <option value="Brazil">Brazil</option>
                                <option value="British Virgin Islands">British Virgin Islands</option>
                                <option value="Brunei Darussalam">Brunei Darussalam</option>
                                <option value="Bulgaria">Bulgaria</option>
                                <option value="Burkina Faso">Burkina Faso</option>
                                <option value="Burundi">Burundi</option>
                                <option value="C">C</option>
                                <option value="Cambodia">Cambodia</option>
                                <option value="Cameroon">Cameroon</option>
                                <option value="Canada">Canada</option>
                                <option value="Cape Verde">Cape Verde</option>
                                <option value="Cayman Islands">Cayman Islands</option>
                                <option value="Central African Republic">Central African Republic</option>
                                <option value="Chad">Chad</option>
                                <option value="Chile">Chile</option>
                                <option value="China">China</option>
                                <option value="Christmas Island">Christmas Island</option>
                                <option value="Cocos (Keeling) Islands">Cocos (Keeling) Islands</option>
                                <option value="Colombia">Colombia</option>
                                <option value="Comoros">Comoros</option>
                                <option value="Congo">Congo</option>
                                <option value="Cook Islands">Cook Islands</option>
                                <option value="Costa Rica">Costa Rica</option>
                                <option value="Croatia">Croatia</option>
                                <option value="Cuba">Cuba</option>
                                <option value="Cyprus">Cyprus</option>
                                <option value="Czech Republic">Czech Republic</option>
                                <option value="Democratic People's Republic of Korea">Democratic People's Republic of Korea</option>
                                <option value="Democratic Republic of the Congo">Democratic Republic of the Congo</option>
                                <option value="Denmark">Denmark</option>
                                <option value="Djibouti">Djibouti</option>
                                <option value="Dominica">Dominica</option>
                                <option value="Dominican Republic">Dominican Republic</option>
                                <option value="Ecuador">Ecuador</option>
                                <option value="Egypt">Egypt</option>
                                <option value="El Salvador">El Salvador</option>
                                <option value="England">England</option>
                                <option value="Equatorial Guinea">Equatorial Guinea</option>
                                <option value="Eritrea">Eritrea</option>
                                <option value="Estonia">Estonia</option>
                                <option value="Ethiopia">Ethiopia</option>
                                <option value="Faeroe Islands">Faeroe Islands</option>
                                <option value="Falkland Islands (Malvinas)">Falkland Islands (Malvinas)</option>
                                <option value="Federated States of Micronesia">Federated States of Micronesia</option>
                                <option value="Fiji">Fiji</option>
                                <option value="Finland">Finland</option>
                                <option value="France">France</option>
                                <option value="France, metropolitan">France, metropolitan</option>
                                <option value="French Guiana">French Guiana</option>
                                <option value="French Polynesia">French Polynesia</option>
                                <option value="Gabon">Gabon</option>
                                <option value="Gambia">Gambia</option>
                                <option value="Georgia">Georgia</option>
                                <option value="Germany">Germany</option>
                                <option value="Ghana">Ghana</option>
                                <option value="Gibraltar">Gibraltar</option>
                                <option value="Greece">Greece</option>
                                <option value="Greenland">Greenland</option>
                                <option value="Grenada">Grenada</option>
                                <option value="Guadeloupe">Guadeloupe</option>
                                <option value="Guam">Guam</option>
                                <option value="Guatemala">Guatemala</option>
                                <option value="Guinea">Guinea</option>
                                <option value="Guinea-Bissau">Guinea-Bissau</option>
                                <option value="Guyana">Guyana</option>
                                <option value="Haiti">Haiti</option>
                                <option value="Holy See">Holy See</option>
                                <option value="Honduras">Honduras</option>
                                <option value="Hong Kong">Hong Kong</option>
                                <option value="Hungary">Hungary</option>
                                <option value="Iceland">Iceland</option>
                                <option value="India">India</option>
                                <option value="Indonesia">Indonesia</option>
                                <option value="Iran">Iran</option>
                                <option value="Iraq">Iraq</option>
                                <option value="Ireland">Ireland</option>
                                <option value="Israel">Israel</option>
                                <option value="Italy">Italy</option>
                                <option value="Jamaica">Jamaica</option>
                                <option value="Japan">Japan</option>
                                <option value="Jordan">Jordan</option>
                                <option value="Kazakhstan">Kazakhstan</option>
                                <option value="Kenya">Kenya</option>
                                <option value="Kiribati">Kiribati</option>
                                <option value="Kuwait">Kuwait</option>
                                <option value="Kyrgyzstan">Kyrgyzstan</option>
                                <option value="Lao">Lao</option>
                                <option value="Latvia">Latvia</option>
                                <option value="Lebanon">Lebanon</option>
                                <option value="Lesotho">Lesotho</option>
                                <option value="Liberia">Liberia</option>
                                <option value="Libyan Arab Jamahiriya">Libyan Arab Jamahiriya</option>
                                <option value="Liechtenstein">Liechtenstein</option>
                                <option value="Lithuania">Lithuania</option>
                                <option value="Luxembourg">Luxembourg</option>
                                <option value="Macau">Macau</option>
                                <option value="Madagascar">Madagascar</option>
                                <option value="Malawi">Malawi</option>
                                <option value="Malaysia">Malaysia</option>
                                <option value="Maldives">Maldives</option>
                                <option value="Mali">Mali</option>
                                <option value="Malta">Malta</option>
                                <option value="Marshall Islands">Marshall Islands</option>
                                <option value="Martinique">Martinique</option>
                                <option value="Mauritania">Mauritania</option>
                                <option value="Mauritius">Mauritius</option>
                                <option value="Mayotte">Mayotte</option>
                                <option value="Mexico">Mexico</option>
                                <option value="Monaco">Monaco</option>
                                <option value="Mongolia">Mongolia</option>
                                <option value="Montserrat">Montserrat</option>
                                <option value="Morocco">Morocco</option>
                                <option value="Mozambique">Mozambique</option>
                                <option value="Myanmar">Myanmar</option>
                                <option value="Namibia">Namibia</option>
                                <option value="Nauru">Nauru</option>
                                <option value="Nepal">Nepal</option>
                                <option value="Netherlands">Netherlands</option>
                                <option value="Netherlands Antilles">Netherlands Antilles</option>
                                <option value="New Caledonia">New Caledonia</option>
                                <option value="New Zealand">New Zealand</option>
                                <option value="Nicaragua">Nicaragua</option>
                                <option value="Niger">Niger</option>
                                <option value="Nigeria">Nigeria</option>
                                <option value="Niue">Niue</option>
                                <option value="Norfolk Island">Norfolk Island</option>
                                <option value="Northern Mariana Islands">Northern Mariana Islands</option>
                                <option value="Norway">Norway</option>
                                <option value="Oman">Oman</option>
                                <option value="Pakistan">Pakistan</option>
                                <option value="Palau">Palau</option>
                                <option value="Panama">Panama</option>
                                <option value="Papua New Guinea">Papua New Guinea</option>
                                <option value="Paraguay">Paraguay</option>
                                <option value="Peru">Peru</option>
                                <option value="Philippines">Philippines</option>
                                <option value="Poland">Poland</option>
                                <option value="Portugal">Portugal</option>
                                <option value="Puerto Rico">Puerto Rico</option>
                                <option value="Qatar">Qatar</option>
                                <option value="R">R</option>
                                <option value="Republic of Korea">Republic of Korea</option>
                                <option value="Republic of Moldova">Republic of Moldova</option>
                                <option value="Romania">Romania</option>
                                <option value="Russian Federation">Russian Federation</option>
                                <option value="Rwanda">Rwanda</option>
                                <option value="S">S</option>
                                <option value="Saint Helena">Saint Helena</option>
                                <option value="Saint Kitts and Nevis">Saint Kitts and Nevis</option>
                                <option value="Saint Lucia">Saint Lucia</option>
                                <option value="Saint Pierre and Miquelon">Saint Pierre and Miquelon</option>
                                <option value="Saint Vincent and the Grenadines">Saint Vincent and the Grenadines</option>
                                <option value="Samoa">Samoa</option>
                                <option value="San Marino">San Marino</option>
                                <option value="Saudi Arabia">Saudi Arabia</option>
                                <option value="Senegal">Senegal</option>
                                <option value="Seychelles">Seychelles</option>
                                <option value="Sierra Leone">Sierra Leone</option>
                                <option value="Singapore">Singapore</option>
                                <option value="Slovakia">Slovakia</option>
                                <option value="Slovenia">Slovenia</option>
                                <option value="Solomon Islands">Solomon Islands</option>
                                <option value="Somalia">Somalia</option>
                                <option value="South Africa">South Africa</option>
                                <option value="Spain">Spain</option>
                                <option value="Sri Lanka">Sri Lanka</option>
                                <option value="Sudan">Sudan</option>
                                <option value="Suriname">Suriname</option>
                                <option value="Swaziland">Swaziland</option>
                                <option value="Sweden">Sweden</option>
                                <option value="Switzerland">Switzerland</option>
                                <option value="Syrian Arab Republic">Syrian Arab Republic</option>
                                <option value="Taiwan">Taiwan</option>
                                <option value="Tajikistan">Tajikistan</option>
                                <option value="Thailand">Thailand</option>
                                <option value="The former Yugoslav Republic of Macedonia">The former Yugoslav Republic of Macedonia</option>
                                <option value="Togo">Togo</option>
                                <option value="Tonga">Tonga</option>
                                <option value="Trinidad and Tobago">Trinidad and Tobago</option>
                                <option value="Tunisia">Tunisia</option>
                                <option value="Turkey">Turkey</option>
                                <option value="Turkmenistan">Turkmenistan</option>
                                <option value="Turks and Caicos Islands">Turks and Caicos Islands</option>
                                <option value="Tuvalu">Tuvalu</option>
                                <option value="Uganda">Uganda</option>
                                <option value="Ukraine">Ukraine</option>
                                <option value="United Arab Emirates">United Arab Emirates</option>
                                <option value="United Kingdom">United Kingdom</option>
                                <option value="United Republic of Tanzania">United Republic of Tanzania</option>
                                <option value="United States">United States</option>
                                <option value="United States Virgin Islands">United States Virgin Islands</option>
                                <option value="Uruguay">Uruguay</option>
                                <option value="Uzbekistan">Uzbekistan</option>
                                <option value="Vanuatu">Vanuatu</option>
                                <option value="Venezuela">Venezuela</option>
                                <option value="Viet Nam">Viet Nam</option>
                                <option value="Yemen">Yemen</option>
                                <option value="Yugoslavia">Yugoslavia</option>
                                <option value="Zambia">Zambia</option>
                                <option value="Zimbabwe">Zimbabwe</option>
                                </select>
                    </td>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label16" Text='<%$ Resources:Resource, DienThoai%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <input runat="server" id="txtPhone" type="text" style="width:150px; height:22px" />
                    </td>
                </tr>
                <tr>
                    <td class="textright"><asp:Label ID="Label17" Text='<%$ Resources:Resource, Fax%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <input  runat="server" id="txtFax" type="text" style="width:150px; height:22px" />
                    </td>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span><asp:Label ID="Label18" Text='<%$ Resources:Resource, Email%>' runat="server" ></asp:Label></td>
                    <td class="textleft">
                        <input runat="server" id="txtEmail" type="text" style="width:200px; height:22px" />
                    </td>
                </tr>
                <%-- <tr>
                    <td class="textright"><span style="color: red">*</span>Phương thức thanh toán</td>
                    <td class="textleft">
                        <input type="text" />
                    </td>
                </tr>
                <tr>
                    <th colspan="2" class="color textleft">Xác nhận yêu cầu</th>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span>Mã bảo vệ</td>
                    <td class="textleft">
                        <input type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="textright"><span style="color: red">*</span>Nhập lại mã bảo vệ</td>
                    <td class="textleft">
                        <input type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="textright"></td>
                    <td class="textleft"></td>
                </tr>--%>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="textright"></td>
                    <td class="textleft">
                        <asp:Button runat="server" ID="btnSend" CssClass="btn_orange" Text="<%$ Resources:Resource, GuiDi%>"  OnClick="btnSend_Click" />
                        <asp:Button runat="server" ID="btnRefresh" CssClass="btn_gray"  Text="<%$ Resources:Resource, NhapLai%>" OnClick="btnRefresh_Click" />
                    </td>
                </tr>
                <%--   <tr>
                    <td colspan="2">Chính sách hủy phòng: Nếu hủy đặt phòng trong vòng 48 tiếng trước ngày khách đến, quý khách phải trả phí hủy phòng tương đương 01 đêm giá phòng đã đặt.</td>
                </tr>
                <tr>
                    <td colspan="2">Đặt phòng của quý vị chỉ được chấp nhận khi qúy vị nhận được xác nhận từ khách sạn và quý vị cung cấp cho chúng tôi chi tiết thẻ tín dụng để đảm bảo đặt phòng.</td>
                </tr>--%>
                        
            </table>
  </ContentTemplate>
                       </asp:UpdatePanel>
        </div>
    </div>
     <script>
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
         function endRequestHandler() {
             $("#<%= txtFrom.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
             $("#<%= txtTo.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
         };
   </script>
</asp:Content>
