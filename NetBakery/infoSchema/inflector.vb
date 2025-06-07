Imports System.Data.Entity.Infrastructure.Pluralization
Imports System.Globalization
Imports System.Text.RegularExpressions

Namespace infoSchema
    Public Class inflector
        Implements IDisposable

        Private Shared _plural As New Dictionary(Of String, Object) From {
            {"rules", New Dictionary(Of String, Object) From {
                {"(s)tatus$", "${1}tatuses"},
                {"(quiz)$", "${1}zes"},
                {"^(ox)$", "${1}${2}en"},
                {"([m|l])ouse$", "${1}ice"},
                {"(matr|vert|ind)(ix|ex)$", "${1}ices"},
                {"(x|ch|ss|sh)$", "${1}es"},
                {"([^aeiouy]|qu)y$", "${1}ies"},
                {"(hive)$", "${1}s"},
                {"(?:([^f])fe|([lre])f)$", "${1}${2}ves"},
                {"sis$", "ses"},
                {"([ti])um$", "${1}a"},
                {"(p)erson$", "${1}eople"},
                {"(?<!u)(m)an$", "${1}en"},
                {"(c)hild$", "${1}hildren"},
                {"(buffal|tomat)o$", "${1}${2}oes"},
                {"(alumn|bacill|cact|foc|fung|nucle|radi|stimul|syllab|termin)us$", "${1}i"},
                {"us$", "uses"},
                {"(alias)$", "${1}es"},
                {"(ax|cris|test)is$", "${1}es"},
                {"s$/", "s"},
                {"^$/", ""},
                {"$/", "s"}
            }},
            {"uninflected", New List(Of String) From {
                ".*[nrlm]ese", ".*data", ".*deer", ".*fish", ".*measles", ".*ois", ".*pox", ".*sheep", "people", "feedback", "stadia"
            }},
            {"irregular", New Dictionary(Of String, Object) From {
                {"atlas", "atlases"},
                {"beef", "beefs"},
                {"brief", "briefs"},
                {"brother", "brothers"},
                {"cafe", "cafes"},
                {"child", "children"},
                {"cookie", "cookies"},
                {"corpus", "corpuses"},
                {"cow", "cows"},
                {"criterion", "criteria"},
                {"ganglion", "ganglions"},
                {"genie", "genies"},
                {"genus", "genera"},
                {"graffito", "graffiti"},
                {"hoof", "hoofs"},
                {"loaf", "loaves"},
                {"man", "men"},
                {"money", "monies"},
                {"mongoose", "mongooses"},
                {"move", "moves"},
                {"mythos", "mythoi"},
                {"niche", "niches"},
                {"numen", "numina"},
                {"occiput", "occiputs"},
                {"octopus", "octopuses"},
                {"opus", "opuses"},
                {"ox", "oxen"},
                {"penis", "penises"},
                {"person", "people"},
                {"sex", "sexes"},
                {"soliloquy", "soliloquies"},
                {"testis", "testes"},
                {"trilby", "trilbys"},
                {"turf", "turfs"},
                {"potato", "potatoes"},
                {"hero", "heroes"},
                {"tooth", "teeth"},
                {"goose", "geese"},
                {"foot", "feet"},
                {"sieve", "sieves"}
            }}
        }

        Private Shared _singular As New Dictionary(Of String, Object) From {
            {"rules", New Dictionary(Of String, Object) From {
                {"(s)tatuses$", "${1}${2}tatus"},
                {"^(.*)(menu)s$", "${1}${2}"},
                {"(quiz)zes$", "${1}"},
                {"(matr)ices$", "${1}ix"},
                {"(vert|ind)ices$", "${1}ex"},
                {"^(ox)en", "${1}"},
                {"(alias)(es)*$", "${1}"},
                {"(alumn|bacill|cact|foc|fung|nucle|radi|stimul|syllab|termin|viri?)i$", "${1}us"},
                {"([ftw]ax)es", "${1}"},
                {"(cris|ax|test)es$", "${1}is"},
                {"(shoe)s$", "${1}"},
                {"(o)es$", "${1}"},
                {"ouses$", "ouse"},
                {"([^a])uses$", "${1}us"},
                {"([m|l])ice$", "${1}ouse"},
                {"(x|ch|ss|sh)es$", "${1}"},
                {"(m)ovies$", "${1}${2}ovie"},
                {"(s)eries$", "${1}${2}eries"},
                {"([^aeiouy]|qu)ies$", "${1}y"},
                {"(tive)s$", "${1}"},
                {"(hive)s$", "${1}"},
                {"(drive)s$", "${1}"},
                {"([le])ves$", "${1}f"},
                {"([^rfoa])ves$", "${1}fe"},
                {"(^analy)ses$", "${1}sis"},
                {"(analy|diagno|^ba|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$", "${1}${2}sis"},
                {"([ti])a$", "${1}um"},
                {"(p)eople$", "${1}${2}erson"},
                {"(m)en$", "${1}an"},
                {"(c)hildren$", "${1}${2}hild"},
                {"(n)ews$", "${1}${2}ews"},
                {"eaus$", "eau"},
                {"^(.*us)$", "${1}"},
                {"s$", ""}
            }},
            {"uninflected", New List(Of String) From {
                ".*data", ".*[nrlm]ese", ".*deer", ".*fish", ".*measles", ".*ois", ".*pox", ".*sheep", ".*ss", "feedback"
            }},
            {"irregular", New Dictionary(Of String, Object) From {
                {"foes", "foe"}
            }}
        }

        Private Shared _uninflected As New List(Of String) From {
            "Amoyese", "bison", "Borghese", "bream", "breeches", "britches", "buffalo", "cantus",
            "carp", "chassis", "clippers", "cod", "coitus", "Congoese", "contretemps", "corps",
            "debris", "diabetes", "djinn", "eland", "elk", "equipment", "Faroese", "flounder",
            "Foochowese", "gallows", "Genevese", "Genoese", "Gilbertese", "graffiti",
            "headquarters", "herpes", "hijinks", "Hottentotese", "information", "innings",
            "jackanapes", "Kiplingese", "Kongoese", "Lucchese", "mackerel", "Maltese", ".*?media",
            "mews", "moose", "mumps", "Nankingese", "news", "nexus", "Niasese",
            "Pekingese", "Piedmontese", "pincers", "Pistoiese", "pliers", "Portuguese",
            "proceedings", "rabies", "research", "rice", "rhinoceros", "salmon", "Sarawakese", "scissors",
            "sea[- ]bass", "series", "Shavese", "shears", "siemens", "species", "swine", "testes",
            "trousers", "trout", "tuna", "Vermontese", "Wenchowese", "whiting", "wildebeest",
            "Yengeese"
        }

        Private Shared _transliteration As New Dictionary(Of String, Object) From {
            {"À|Á|Â|Ã|Å|Ǻ|Ā|Ă|Ą|Ǎ", "A"},
            {"Æ|Ǽ", "AE"},
            {"Ä", "Ae"},
            {"Ç|Ć|Ĉ|Ċ|Č", "C"},
            {"Ð|Ď|Đ", "D"},
            {"È|É|Ê|Ë|Ē|Ĕ|Ė|Ę|Ě", "E"},
            {"Ĝ|Ğ|Ġ|Ģ|Ґ", "G"},
            {"Ĥ|Ħ", "H"},
            {"Ì|Í|Î|Ï|Ĩ|Ī|Ĭ|Ǐ|Į|İ|І", "I"},
            {"Ĳ", "IJ"},
            {"Ĵ", "J"},
            {"Ķ", "K"},
            {"Ĺ|Ļ|Ľ|Ŀ|Ł", "L"},
            {"Ñ|Ń|Ņ|Ň", "N"},
            {"Ò|Ó|Ô|Õ|Ō|Ŏ|Ǒ|Ő|Ơ|Ø|Ǿ", "O"},
            {"Œ", "OE"},
            {"Ö", "Oe"},
            {"Ŕ|Ŗ|Ř", "R"},
            {"Ś|Ŝ|Ş|Ș|Š", "S"},
            {"ẞ", "SS"},
            {"Ţ|Ț|Ť|Ŧ", "T"},
            {"Þ", "TH"},
            {"Ù|Ú|Û|Ũ|Ū|Ŭ|Ů|Ű|Ų|Ư|Ǔ|Ǖ|Ǘ|Ǚ|Ǜ", "U"},
            {"Ü", "Ue"},
            {"Ŵ", "W"},
            {"Ý|Ÿ|Ŷ", "Y"},
            {"Є", "Ye"},
            {"Ї", "Yi"},
            {"Ź|Ż|Ž", "Z"},
            {"à|á|â|ã|å|ǻ|ā|ă|ą|ǎ|ª", "a"},
            {"ä|æ|ǽ", "ae"},
            {"ç|ć|ĉ|ċ|č", "c"},
            {"ð|ď|đ", "d"},
            {"è|é|ê|ë|ē|ĕ|ė|ę|ě", "e"},
            {"ƒ", "f"},
            {"ĝ|ğ|ġ|ģ|ґ", "g"},
            {"ĥ|ħ", "h"},
            {"ì|í|î|ï|ĩ|ī|ĭ|ǐ|į|ı|і", "i"},
            {"ĳ", "ij"},
            {"ĵ", "j"},
            {"ķ", "k"},
            {"ĺ|ļ|ľ|ŀ|ł", "l"},
            {"ñ|ń|ņ|ň|ŉ", "n"},
            {"ò|ó|ô|õ|ō|ŏ|ǒ|ő|ơ|ø|ǿ|º", "o"},
            {"ö|œ", "oe"},
            {"ŕ|ŗ|ř", "r"},
            {"ś|ŝ|ş|ș|š|ſ", "s"},
            {"ß", "ss"},
            {"ţ|ț|ť|ŧ", "t"},
            {"þ", "th"},
            {"ù|ú|û|ũ|ū|ŭ|ů|ű|ų|ư|ǔ|ǖ|ǘ|ǚ|ǜ", "u"},
            {"ü", "ue"},
            {"ŵ", "w"},
            {"ý|ÿ|ŷ", "y"},
            {"є", "ye"},
            {"ї", "yi"},
            {"ź|ż|ž", "z"}
        }

        Private Shared _cache As New Dictionary(Of String, Object)

        Private Shared _initialState As New Dictionary(Of String, Object)

        Private Shared Function Cache(type As String, key As String, Optional value As Object = Nothing) As Object
            key = "_" & key
            type = "_" & type

            If value IsNot Nothing Then
                If Not _cache.ContainsKey(type) Then
                    _cache(type) = New Dictionary(Of String, Object)()
                End If

                Dim typeDict = CType(_cache(type), Dictionary(Of String, Object))
                typeDict(key) = value
                Return value
            End If

            If _cache.ContainsKey(type) Then
                Dim typeDict = CType(_cache(type), Dictionary(Of String, Object))
                If typeDict.ContainsKey(key) Then
                    Return typeDict(key)
                End If
            End If

            Return Nothing
        End Function

        Public Shared Sub Reset()
            If _initialState.Count = 0 Then
                _initialState = New Dictionary(Of String, Object) From {
                    {"_plural", _plural},
                    {"_singular", _singular},
                    {"_uninflected", _uninflected},
                    {"_transliteration", _transliteration},
                    {"_cache", _cache}
                }
                Return
            End If

            For Each kvp In _initialState
                If kvp.Key <> "_initialState" Then
                    Select Case kvp.Key
                        Case "_plural" : _plural = CType(kvp.Value, Dictionary(Of String, Object))
                        Case "_singular" : _singular = CType(kvp.Value, Dictionary(Of String, Object))
                        Case "_uninflected" : _uninflected = CType(kvp.Value, List(Of String))
                        Case "_transliteration" : _transliteration = CType(kvp.Value, Dictionary(Of String, Object))
                        Case "_cache" : _cache = CType(kvp.Value, Dictionary(Of String, Object))
                    End Select
                End If
            Next
        End Sub

        Public Shared Sub Rules(type As String, rules As Dictionary(Of String, Object), Optional reset As Boolean = False)
            Dim varName As String = "_" & type

            Select Case type
                Case "transliteration"
                    If reset Then
                        _transliteration = New Dictionary(Of String, Object)(rules)
                    Else
                        For Each kvp In _transliteration
                            If Not rules.ContainsKey(kvp.Key) Then
                                rules(kvp.Key) = kvp.Value
                            End If
                        Next
                        _transliteration = rules
                    End If

                Case Else
                    Dim target = GetField(varName)

                    For Each rule In rules.Keys.ToList()
                        Dim pattern = rules(rule)
                        If TypeOf pattern Is IEnumerable(Of String) OrElse TypeOf pattern Is Dictionary(Of String, Object) Then
                            If reset Then
                                target(rule) = pattern
                            Else
                                If rule = "uninflected" Then
                                    Dim existing = CType(target(rule), List(Of String))
                                    Dim updated = New List(Of String)(CType(pattern, List(Of String)))
                                    updated.AddRange(existing)
                                    target(rule) = updated
                                Else
                                    Dim existing = CType(target(rule), Dictionary(Of String, Object))
                                    For Each k In CType(pattern, Dictionary(Of String, Object))
                                        If Not existing.ContainsKey(k.Key) Then
                                            existing(k.Key) = k.Value
                                        End If
                                    Next
                                    target(rule) = existing
                                End If
                            End If

                            ' Clear cached values
                            If target.ContainsKey("cache" & CultureInfo.InvariantCulture.TextInfo.ToTitleCase(rule)) Then
                                target.Remove("cache" & CultureInfo.InvariantCulture.TextInfo.ToTitleCase(rule))
                            End If
                            If target.ContainsKey("merged") AndAlso CType(target("merged"), Dictionary(Of String, Object)).ContainsKey(rule) Then
                                CType(target("merged"), Dictionary(Of String, Object)).Remove(rule)
                            End If

                            If type = "plural" Then
                                _cache("pluralize") = New Dictionary(Of String, Object)()
                                _cache("tableize") = New Dictionary(Of String, Object)()
                            ElseIf type = "singular" Then
                                _cache("singularize") = New Dictionary(Of String, Object)()
                            End If

                            rules.Remove(rule)
                        End If
                    Next

                    ' Merge remaining rules
                    Dim rulesDict = CType(target("rules"), Dictionary(Of String, Object))
                    For Each kvp In rules
                        If Not rulesDict.ContainsKey(kvp.Key) Then
                            rulesDict(kvp.Key) = kvp.Value
                        End If
                    Next
                    target("rules") = rulesDict
            End Select
        End Sub
        Private Shared Function GetField(name As String) As Dictionary(Of String, Object)
            Select Case name
                Case "_plural" : Return _plural
                Case "_singular" : Return _singular
                Case Else : Throw New ArgumentException("Invalid type name.")
            End Select
        End Function

        Public Shared Function Pluralize(word As String) As String
            ' Check cache
            If _cache.ContainsKey("pluralize") AndAlso CType(_cache("pluralize"), Dictionary(Of String, String)).ContainsKey(word) Then
                Return CType(_cache("pluralize"), Dictionary(Of String, String))(word)
            End If

            ' Merge irregular
            If Not _plural.ContainsKey("merged") Then
                _plural("merged") = New Dictionary(Of String, Object)()
            End If
            Dim merged = CType(_plural("merged"), Dictionary(Of String, Object))

            If Not merged.ContainsKey("irregular") Then
                merged("irregular") = _plural("irregular")
            End If

            ' Merge uninflected
            If Not merged.ContainsKey("uninflected") Then
                merged("uninflected") = CType(_plural("uninflected"), List(Of String)).Concat(_uninflected).ToList()
            End If

            ' Cache regex
            If Not _plural.ContainsKey("cacheUninflected") OrElse Not _plural.ContainsKey("cacheIrregular") Then
                Dim uninflectedList = CType(merged("uninflected"), List(Of String))
                Dim irregularDict = CType(merged("irregular"), Dictionary(Of String, String))
                _plural("cacheUninflected") = "(?:" & String.Join("|", uninflectedList) & ")"
                _plural("cacheIrregular") = "(?:" & String.Join("|", irregularDict.Keys) & ")"
            End If

            Dim cacheUninflected As String = CStr(_plural("cacheUninflected"))
            Dim cacheIrregular As String = CStr(_plural("cacheIrregular"))

            ' Regex match irregular
            Dim matchIrregular As Match = Regex.Match(word, "(.*?(?:\b|_))(" & cacheIrregular & ")$", RegexOptions.IgnoreCase)
            If matchIrregular.Success Then
                Dim prefix = matchIrregular.Groups(1).Value
                Dim base = matchIrregular.Groups(2).Value
                Dim irregulars = CType(merged("irregular"), Dictionary(Of String, String))
                Dim lower = base.ToLower()
                Dim replacement = irregulars(lower)
                Dim result = prefix & base.Substring(0, 1) & replacement.Substring(1)

                If Not _cache.ContainsKey("pluralize") Then _cache("pluralize") = New Dictionary(Of String, String)()
                CType(_cache("pluralize"), Dictionary(Of String, String))(word) = result
                Return result
            End If

            ' Regex match uninflected
            If Regex.IsMatch(word, "^(" & cacheUninflected & ")$", RegexOptions.IgnoreCase) Then
                If Not _cache.ContainsKey("pluralize") Then _cache("pluralize") = New Dictionary(Of String, String)()
                CType(_cache("pluralize"), Dictionary(Of String, String))(word) = word
                Return word
            End If

            ' Apply plural rules
            Dim rules = CType(_plural("rules"), Dictionary(Of String, String))
            For Each rule In rules
                If Regex.IsMatch(word, rule.Key) Then
                    Dim replaced = Regex.Replace(word, rule.Key, rule.Value)
                    If Not _cache.ContainsKey("pluralize") Then _cache("pluralize") = New Dictionary(Of String, String)()
                    CType(_cache("pluralize"), Dictionary(Of String, String))(word) = replaced
                    Return replaced
                End If
            Next

            Return word
        End Function

        Public Shared Function Singularize(word As String) As String
            ' Check cache
            If _cache.ContainsKey("singularize") AndAlso CType(_cache("singularize"), Dictionary(Of String, String)).ContainsKey(word) Then
                Return CType(_cache("singularize"), Dictionary(Of String, String))(word)
            End If

            ' Ensure 'merged' exists
            If Not _singular.ContainsKey("merged") Then
                _singular("merged") = New Dictionary(Of String, Object)()
            End If
            Dim merged = CType(_singular("merged"), Dictionary(Of String, Object))

            ' Merge uninflected
            If Not merged.ContainsKey("uninflected") Then
                merged("uninflected") = CType(_singular("uninflected"), List(Of String)).Concat(_uninflected).ToList()
            End If

            ' Merge irregular with flipped plural irregular
            If Not merged.ContainsKey("irregular") Then
                Dim singularIrregular = New Dictionary(Of String, String)(CType(_singular("irregular"), Dictionary(Of String, String)))
                For Each kvp In CType(_plural("irregular"), Dictionary(Of String, String))
                    If Not singularIrregular.ContainsKey(kvp.Value.ToLower()) Then
                        singularIrregular(kvp.Value.ToLower()) = kvp.Key
                    End If
                Next
                merged("irregular") = singularIrregular
            End If

            ' Cache regex
            If Not _singular.ContainsKey("cacheUninflected") OrElse Not _singular.ContainsKey("cacheIrregular") Then
                Dim uninflectedList = CType(merged("uninflected"), List(Of String))
                Dim irregularDict = CType(merged("irregular"), Dictionary(Of String, String))
                _singular("cacheUninflected") = "(?:" & String.Join("|", uninflectedList) & ")"
                _singular("cacheIrregular") = "(?:" & String.Join("|", irregularDict.Keys) & ")"
            End If

            Dim cacheUninflected As String = CStr(_singular("cacheUninflected"))
            Dim cacheIrregular As String = CStr(_singular("cacheIrregular"))

            ' Regex match irregular
            Dim matchIrregular As Match = Regex.Match(word, "(.*?(?:\b|_))(" & cacheIrregular & ")$", RegexOptions.IgnoreCase)
            If matchIrregular.Success Then
                Dim prefix = matchIrregular.Groups(1).Value
                Dim base = matchIrregular.Groups(2).Value
                Dim irregulars = CType(merged("irregular"), Dictionary(Of String, String))
                Dim lower = base.ToLower()
                Dim replacement = irregulars(lower)
                Dim result = prefix & base.Substring(0, 1) & replacement.Substring(1)

                If Not _cache.ContainsKey("singularize") Then _cache("singularize") = New Dictionary(Of String, String)()
                CType(_cache("singularize"), Dictionary(Of String, String))(word) = result
                Return result
            End If

            ' Regex match uninflected
            If Regex.IsMatch(word, "^(" & cacheUninflected & ")$", RegexOptions.IgnoreCase) Then
                If Not _cache.ContainsKey("singularize") Then _cache("singularize") = New Dictionary(Of String, String)()
                CType(_cache("singularize"), Dictionary(Of String, String))(word) = word
                Return word
            End If

            ' Apply singular rules
            Dim rules = CType(_singular("rules"), Dictionary(Of String, String))
            For Each rule In rules
                If Regex.IsMatch(word, rule.Key) Then
                    Dim replaced = Regex.Replace(word, rule.Key, rule.Value)
                    If Not _cache.ContainsKey("singularize") Then _cache("singularize") = New Dictionary(Of String, String)()
                    CType(_cache("singularize"), Dictionary(Of String, String))(word) = replaced
                    Return replaced
                End If
            Next

            ' Default return
            If Not _cache.ContainsKey("singularize") Then _cache("singularize") = New Dictionary(Of String, String)()
            CType(_cache("singularize"), Dictionary(Of String, String))(word) = word
            Return word
        End Function

        Public Shared Function Camelize(lowerCaseAndUnderscoredWord As String) As String
            Dim cacheKey = "Camelize"
            If Not _cache.ContainsKey(cacheKey) Then _cache(cacheKey) = New Dictionary(Of String, String)()
            Dim cacheDict = CType(_cache(cacheKey), Dictionary(Of String, String))

            If cacheDict.ContainsKey(lowerCaseAndUnderscoredWord) Then
                Return cacheDict(lowerCaseAndUnderscoredWord)
            End If

            Dim result = Humanize(lowerCaseAndUnderscoredWord).Replace(" ", "")
            cacheDict(lowerCaseAndUnderscoredWord) = result
            Return result
        End Function

        Public Shared Function Underscore(camelCasedWord As String) As String
            Dim cacheKey = "Underscore"
            If Not _cache.ContainsKey(cacheKey) Then _cache(cacheKey) = New Dictionary(Of String, String)()
            Dim cacheDict = CType(_cache(cacheKey), Dictionary(Of String, String))

            If cacheDict.ContainsKey(camelCasedWord) Then
                Return cacheDict(camelCasedWord)
            End If

            Dim underscored = Regex.Replace(camelCasedWord, "(?<=\w)([A-Z])", "_$1")
            Dim result = underscored.ToLowerInvariant()
            cacheDict(camelCasedWord) = result
            Return result
        End Function

        Public Shared Function Humanize(lowerCaseAndUnderscoredWord As String) As String
            Dim cacheKey = "Humanize"
            If Not _cache.ContainsKey(cacheKey) Then _cache(cacheKey) = New Dictionary(Of String, String)()
            Dim cacheDict = CType(_cache(cacheKey), Dictionary(Of String, String))

            If cacheDict.ContainsKey(lowerCaseAndUnderscoredWord) Then
                Return cacheDict(lowerCaseAndUnderscoredWord)
            End If

            Dim parts = lowerCaseAndUnderscoredWord.Replace("_", " ").Split(" "c)
            For i As Integer = 0 To parts.Length - 1
                If parts(i).Length > 0 Then
                    parts(i) = Char.ToUpperInvariant(parts(i)(0)) & parts(i).Substring(1)
                End If
            Next
            Dim result = String.Join(" ", parts)
            cacheDict(lowerCaseAndUnderscoredWord) = result
            Return result
        End Function

        Public Shared Function Tableize(className As String) As String
            Dim cacheKey = "Tableize"
            If Not _cache.ContainsKey(cacheKey) Then _cache(cacheKey) = New Dictionary(Of String, String)()
            Dim cacheDict = CType(_cache(cacheKey), Dictionary(Of String, String))

            If cacheDict.ContainsKey(className) Then
                Return cacheDict(className)
            End If

            Dim result = Pluralize(Underscore(className))
            cacheDict(className) = result
            Return result
        End Function

        Public Shared Function Classify(tableName As String) As String
            Dim cacheKey = "Classify"
            If Not _cache.ContainsKey(cacheKey) Then _cache(cacheKey) = New Dictionary(Of String, String)()
            Dim cacheDict = CType(_cache(cacheKey), Dictionary(Of String, String))

            If cacheDict.ContainsKey(tableName) Then
                Return cacheDict(tableName)
            End If

            Dim result = Camelize(Singularize(tableName))
            cacheDict(tableName) = result
            Return result
        End Function

        Public Shared Function [Variable](str As String) As String
            Dim cacheKey = "Variable"
            If Not _cache.ContainsKey(cacheKey) Then _cache(cacheKey) = New Dictionary(Of String, String)()
            Dim cacheDict = CType(_cache(cacheKey), Dictionary(Of String, String))

            If cacheDict.ContainsKey(str) Then
                Return cacheDict(str)
            End If

            Dim camelized = Camelize(Underscore(str))
            Dim result As String
            If camelized.Length > 0 Then
                result = Regex.Replace(camelized, "\w", LCase(camelized.Substring(0, 1)))
            Else
                result = camelized
            End If

            cacheDict(str) = result
            Return result
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class

    'Public Class PluralizationService
    '    Private _service As EnglishPluralizationService

    '    Public Sub New()
    '        Try
    '            If My.Settings.customDictionary.Count > 0 Then

    '                Dim userEntries As New List(Of CustomPluralizationEntry)

    '                For Each s In My.Settings.customDictionary
    '                    userEntries.Add(New CustomPluralizationEntry(s.Split("|"c).First, s.Split("|"c).Last))
    '                Next
    '                _service = New EnglishPluralizationService(userEntries)
    '            Else
    '                _service = New EnglishPluralizationService()
    '            End If

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub

    '    Public Function Singularize(s As String) As String
    '        'Return ret
    '        Dim ret As String = _service.Singularize(s)

    '        Dim test As String

    '        ' it did not singularize, is it already single?
    '        If ret = s Then
    '            test = _service.Pluralize(s)


    '            If test = s Then ' it did not pluralize either, maybe its two words....
    '                If s.Contains("_"c) AndAlso Not s.EndsWith("_"c) Then
    '                    Dim l = s.Split("_"c).LastOrDefault

    '                    test = _service.Singularize(l)
    '                    ret = s.Replace(l, test)


    '                    If ret = s Then ' no way to make it single, return s

    '                        ret = s
    '                    End If

    '                Else
    '                    ret = s
    '                End If

    '            Else ' it did pluralize, return s
    '                ret = s
    '            End If
    '        End If

    '        Return ret
    '    End Function

    '    Public Function Pluralize(s As String) As String
    '        Dim ret As String = _service.Pluralize(s)
    '        Dim test As String = Singularize(s)

    '        If s = ret AndAlso s = test AndAlso test = ret Then ret &= "s"

    '        Return ret
    '    End Function

    '    Public Function isSingle(s As String) As Boolean
    '        Dim tmp As String = Singularize(s)

    '        Return tmp.Equals(s)
    '    End Function

    '    Public Function TryParse(s As String) As CustomPluralizationEntry
    '        Try
    '            Dim singleName As String
    '            Dim pluralName As String

    '            If isSingle(s) Then
    '                singleName = s
    '                pluralName = Pluralize(s)
    '            Else
    '                singleName = Singularize(s)
    '                pluralName = s
    '            End If

    '            Return New CustomPluralizationEntry(singleName, pluralName)
    '        Catch ex As Exception
    '            Return Nothing
    '        End Try
    '    End Function
    'End Class

End Namespace


