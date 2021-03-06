﻿using AgendaOnline.Client.Model.Entities;

namespace AgendaOnline.Client.Model
{
    public class CountriesRepository
    {
        public Country[] GetAll()
        {
            return new[]
                {
                    //see http://countrycode.org/
                    new Country(1, "United States"),
                    new Country(93, "Afghanistan"),
                    new Country(355, "Albania"),
                    new Country(213, "Algeria"),
                    new Country(1684, "American Samoa"),
                    new Country(376, "Andorra"),
                    new Country(244, "Angola"),
                    new Country(1264, "Anguilla"),
                    new Country(672, "Antarctica"),
                    new Country(1268, "Antigua and Barbuda"),
                    new Country(54, "Argentina"),
                    new Country(374, "Armenia"),
                    new Country(297, "Aruba"),
                    new Country(61, "Australia"),
                    new Country(43, "Austria"),
                    new Country(994, "Azerbaijan"),
                    new Country(1242, "Bahamas"),
                    new Country(973, "Bahrain"),
                    new Country(880, "Bangladesh"),
                    new Country(1246, "Barbados"),
                    new Country(375, "Belarus"),
                    new Country(32, "Belgium"),
                    new Country(501, "Belize"),
                    new Country(229, "Benin"),
                    new Country(1441, "Bermuda"),
                    new Country(975, "Bhutan"),
                    new Country(591, "Bolivia"),
                    new Country(387, "Bosnia and Herzegovina"),
                    new Country(267, "Botswana"),
                    new Country(55, "Brazil"),
                    new Country(1284, "British Virgin Islands"),
                    new Country(673, "Brunei"),
                    new Country(359, "Bulgaria"),
                    new Country(226, "Burkina Faso"),
                    new Country(95, "Burma (Myanmar)"),
                    new Country(257, "Burundi"),
                    new Country(855, "Cambodia"),
                    new Country(237, "Cameroon"),
                    new Country(1, "Canada"),
                    new Country(238, "Cape Verde"),
                    new Country(1345, "Cayman Islands"),
                    new Country(236, "Central African Republic"),
                    new Country(235, "Chad"),
                    new Country(56, "Chile"),
                    new Country(86, "China"),
                    new Country(61, "Christmas Island"),
                    new Country(61, "Cocos (Keeling) Islands"),
                    new Country(57, "Colombia"),
                    new Country(269, "Comoros"),
                    new Country(682, "Cook Islands"),
                    new Country(506, "Costa Rica"),
                    new Country(385, "Croatia"),
                    new Country(53, "Cuba"),
                    new Country(357, "Cyprus"),
                    new Country(420, "Czech Republic"),
                    new Country(243, "Democratic Republic of the Congo"),
                    new Country(45, "Denmark"),
                    new Country(253, "Djibouti"),
                    new Country(1767, "Dominica"),
                    new Country(1809, "Dominican Republic"),
                    new Country(593, "Ecuador"),
                    new Country(20, "Egypt"),
                    new Country(503, "El Salvador"),
                    new Country(240, "Equatorial Guinea"),
                    new Country(291, "Eritrea"),
                    new Country(372, "Estonia"),
                    new Country(251, "Ethiopia"),
                    new Country(500, "Falkland Islands"),
                    new Country(298, "Faroe Islands"),
                    new Country(679, "Fiji"),
                    new Country(358, "Finland"),
                    new Country(33, "France"),
                    new Country(689, "French Polynesia"),
                    new Country(241, "Gabon"),
                    new Country(220, "Gambia"),
                    new Country(970, "Gaza Strip"),
                    new Country(995, "Georgia"),
                    new Country(49, "Germany"),
                    new Country(233, "Ghana"),
                    new Country(350, "Gibraltar"),
                    new Country(30, "Greece"),
                    new Country(299, "Greenland"),
                    new Country(1473, "Grenada"),
                    new Country(1671, "Guam"),
                    new Country(502, "Guatemala"),
                    new Country(224, "Guinea"),
                    new Country(245, "Guinea-Bissau"),
                    new Country(592, "Guyana"),
                    new Country(509, "Haiti"),
                    new Country(39, "Holy See (Vatican City)"),
                    new Country(504, "Honduras"),
                    new Country(852, "Hong Kong"),
                    new Country(36, "Hungary"),
                    new Country(354, "Iceland"),
                    new Country(91, "India"),
                    new Country(62, "Indonesia"),
                    new Country(98, "Iran"),
                    new Country(964, "Iraq"),
                    new Country(353, "Ireland"),
                    new Country(44, "Isle of Man"),
                    new Country(972, "Israel"),
                    new Country(39, "Italy"),
                    new Country(225, "Ivory Coast"),
                    new Country(1876, "Jamaica"),
                    new Country(81, "Japan"),
                    new Country(962, "Jordan"),
                    new Country(7, "Kazakhstan"),
                    new Country(254, "Kenya"),
                    new Country(686, "Kiribati"),
                    new Country(381, "Kosovo"),
                    new Country(965, "Kuwait"),
                    new Country(996, "Kyrgyzstan"),
                    new Country(856, "Laos"),
                    new Country(371, "Latvia"),
                    new Country(961, "Lebanon"),
                    new Country(266, "Lesotho"),
                    new Country(231, "Liberia"),
                    new Country(218, "Libya"),
                    new Country(423, "Liechtenstein"),
                    new Country(370, "Lithuania"),
                    new Country(352, "Luxembourg"),
                    new Country(853, "Macau"),
                    new Country(389, "Macedonia"),
                    new Country(261, "Madagascar"),
                    new Country(265, "Malawi"),
                    new Country(60, "Malaysia"),
                    new Country(960, "Maldives"),
                    new Country(223, "Mali"),
                    new Country(356, "Malta"),
                    new Country(692, "Marshall Islands"),
                    new Country(222, "Mauritania"),
                    new Country(230, "Mauritius"),
                    new Country(262, "Mayotte"),
                    new Country(52, "Mexico"),
                    new Country(691, "Micronesia"),
                    new Country(373, "Moldova"),
                    new Country(377, "Monaco"),
                    new Country(976, "Mongolia"),
                    new Country(382, "Montenegro"),
                    new Country(1664, "Montserrat"),
                    new Country(212, "Morocco"),
                    new Country(258, "Mozambique"),
                    new Country(264, "Namibia"),
                    new Country(674, "Nauru"),
                    new Country(977, "Nepal"),
                    new Country(31, "Netherlands"),
                    new Country(599, "Netherlands Antilles"),
                    new Country(687, "New Caledonia"),
                    new Country(64, "New Zealand"),
                    new Country(505, "Nicaragua"),
                    new Country(227, "Niger"),
                    new Country(234, "Nigeria"),
                    new Country(683, "Niue"),
                    new Country(672, "Norfolk Island"),
                    new Country(850, "North Korea"),
                    new Country(1670, "Northern Mariana Islands"),
                    new Country(47, "Norway"),
                    new Country(968, "Oman"),
                    new Country(92, "Pakistan"),
                    new Country(680, "Palau"),
                    new Country(507, "Panama"),
                    new Country(675, "Papua New Guinea"),
                    new Country(595, "Paraguay"),
                    new Country(51, "Peru"),
                    new Country(63, "Philippines"),
                    new Country(870, "Pitcairn Islands"),
                    new Country(48, "Poland"),
                    new Country(351, "Portugal"),
                    new Country(1, "Puerto Rico"),
                    new Country(974, "Qatar"),
                    new Country(242, "Republic of the Congo"),
                    new Country(40, "Romania"),
                    new Country(7, "Russia"),
                    new Country(250, "Rwanda"),
                    new Country(590, "Saint Barthelemy"),
                    new Country(290, "Saint Helena"),
                    new Country(1869, "Saint Kitts and Nevis"),
                    new Country(1758, "Saint Lucia"),
                    new Country(1599, "Saint Martin"),
                    new Country(508, "Saint Pierre and Miquelon"),
                    new Country(1784, "Saint Vincent and the Grenadines"),
                    new Country(685, "Samoa"),
                    new Country(378, "San Marino"),
                    new Country(239, "Sao Tome and Principe"),
                    new Country(966, "Saudi Arabia"),
                    new Country(221, "Senegal"),
                    new Country(381, "Serbia"),
                    new Country(248, "Seychelles"),
                    new Country(232, "Sierra Leone"),
                    new Country(65, "Singapore"),
                    new Country(421, "Slovakia"),
                    new Country(386, "Slovenia"),
                    new Country(677, "Solomon Islands"),
                    new Country(252, "Somalia"),
                    new Country(27, "South Africa"),
                    new Country(82, "South Korea"),
                    new Country(34, "Spain"),
                    new Country(94, "Sri Lanka"),
                    new Country(249, "Sudan"),
                    new Country(597, "Suriname"),
                    new Country(268, "Swaziland"),
                    new Country(46, "Sweden"),
                    new Country(41, "Switzerland"),
                    new Country(963, "Syria"),
                    new Country(886, "Taiwan"),
                    new Country(992, "Tajikistan"),
                    new Country(255, "Tanzania"),
                    new Country(66, "Thailand"),
                    new Country(670, "Timor-Leste"),
                    new Country(228, "Togo"),
                    new Country(690, "Tokelau"),
                    new Country(676, "Tonga"),
                    new Country(1868, "Trinidad and Tobago"),
                    new Country(216, "Tunisia"),
                    new Country(90, "Turkey"),
                    new Country(993, "Turkmenistan"),
                    new Country(1649, "Turks and Caicos Islands"),
                    new Country(688, "Tuvalu"),
                    new Country(256, "Uganda"),
                    new Country(380, "Ukraine"),
                    new Country(971, "United Arab Emirates"),
                    new Country(44, "United Kingdom"),
                    new Country(1, "United States"),
                    new Country(598, "Uruguay"),
                    new Country(1340, "US Virgin Islands"),
                    new Country(998, "Uzbekistan"),
                    new Country(678, "Vanuatu"),
                    new Country(58, "Venezuela"),
                    new Country(84, "Vietnam"),
                    new Country(681, "Wallis and Futuna"),
                    new Country(970, "West Bank"),
                    new Country(967, "Yemen"),
                    new Country(260, "Zambia"),
                    new Country(263, "Zimbabwe"),
                };
        }
    }
}
