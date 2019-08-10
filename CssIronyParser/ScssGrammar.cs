using Irony.Parsing;
using System;

namespace ScssIronyParser
{
    [Language("SCSS", "1.0", "")]
    public class ScssGrammar : Grammar
    {
        public ScssGrammar()
        {
            #region 1. Terminals

            var left_brace = ToTerm("{");
            var right_brace = ToTerm("}");
            var colon = ToTerm(":");
            var semicolon = ToTerm(";");
            var single_quote = ToTerm("'");
            var forward_slash = ToTerm("/");
            var left_round = ToTerm("(");
            var right_round = ToTerm(")");
            var left_square_b = ToTerm("[");
            var right_square_b = ToTerm("]");
            var less_than = ToTerm("<");
            var le_than = ToTerm("<=");
            var greater_than = ToTerm(">");
            var ge_than = ToTerm(">");

            //  var name = new RegexBasedTerminal(@"([_a-zA-Z0-9-]|([^\0-\177])|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))+");
            ////   var ident = new RegexBasedTerminal(@"[-]?([_a-z]|[^\0-\177]|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))([_a-zA-Z0-9-]|[^\0-\177]|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))*");
            //    var S = new RegexBasedTerminal(@"[ \t\r\n\f]+");
            //var num = new RegexBasedTerminal(@"[+-]?([0-9]+|[0-9]*\.[0-9]+)(e[+-]?[0-9]+)?");
            //var string1 = new RegexBasedTerminal(@"""([^\n\r\f""]|\(\n|\r\n|\r|\f)|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f])*""");
            // var string2 = new RegexBasedTerminal(@"'([^\n\r\f']|\(\n|\r\n|\r|\f)|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f])*'");
            var comma = ToTerm(",");

            var color_rgb = new RegexBasedTerminal("colorRGB", @"#[0-9a-f]{1,6}");

            var comment = new CommentTerminal("COMMENT", "/*", "*/");
            var line_comment = new CommentTerminal("LINE_COMMENT", "//", "\n");

            var charset = ToTerm("@charset");
            var import = ToTerm("@import");
            var font = ToTerm("font");
            var url = ToTerm("url");
            var mixin = ToTerm("@mixin");
            var include = ToTerm("@include");

            var single_quotestr = new StringLiteral("single_quotestr", "'");
            var double_quotestr = new StringLiteral("double_quotestr", "\"");

            //  var dashmatch = ToTerm(@"|=");
            //var includes = ToTerm(@"~=");

            //var uri_0 = new RegexBasedTerminal(@"(u|\0(0,4)(55|75)(\r\n|[ \t\r\n\f])?|\\u)(r|\0(0,4)(52|72)(\r\n|[ \t\r\n\f])?|\r)(l|\0(0,4)(4c|6c)(\r\n|[ \t\r\n\f])?|\\l)\(([ \t\r\n\f]*)((""([^\n\r\f\""]|\(\n|\r\n|\r|\f)|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))*"")|('([^\n\r\f\']|\(\n|\r\n|\r|\f)|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))*'([ \t\r\n\f]*)\)");
            //var uri_1 = new RegexBasedTerminal(@"(u|\0(0,4)(55|75)(\r\n|[ \t\r\n\f])?|\\u)(r|\0(0,4)(52|72)(\r\n|[ \t\r\n\f])?|\r)(l|\0(0,4)(4c|6c)(\r\n|[ \t\r\n\f])?|\\l)\(([ \t\r\n\f]*)([!#$%&*-\[\]-~]|([^\0-\177])|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\\[^\n\r\f0-9a-f]))*([ \t\r\n\f]*)\)");

            //var unicode_0 = new RegexBasedTerminal("unicode_0", @"u\+[?]{1,6}");
            //var unicode_1 = new RegexBasedTerminal("unicode_1", @"u\+[0-9a-f]{1}[?]{0,5}");
            //var unicode_2 = new RegexBasedTerminal("unicode_2", @"u\+[0-9a-f]{2}[?]{0,4}");
            //var unicode_3 = new RegexBasedTerminal("unicode_3", @"u\+[0-9a-f]{3}[?]{0,3}");
            //var unicode_4 = new RegexBasedTerminal("unicode_4", @"u\+[0-9a-f]{4}[?]{0,2}");
            //var unicode_5 = new RegexBasedTerminal("unicode_5", @"u\+[0-9a-f]{5}[?]{0,1}");
            //var unicode_6 = new RegexBasedTerminal("unicode_6", @"u\+[0-9a-f]{6}");
            //var unicode_7 = new RegexBasedTerminal("unicode_7", @"u\+[0-9a-f]{1,6}-[0-9a-f]{1,6}");

            var dash_ident = new IdentifierTerminal("dash_ident", "-", "-");
            var NUMBER = new NumberLiteral("NUMBER", NumberOptions.DisableQuickParse);
            var css_number = new NumberLiteral("CSS_NUMBER", NumberOptions.AllowLetterAfter | NumberOptions.AllowSign);
            var percentage = new RegexBasedTerminal("PERCENTAGE", @"[0-9]+[\%]");
            var zero_terminal = new RegexBasedTerminal("ZERO_TERMINAL", @"[0]");

            NonGrammarTerminals.Add(comment);
            NonGrammarTerminals.Add(line_comment);

            #endregion

            #region 2. Non-terminals
            var CSS_UNIT = new NonTerminal("CSS_UNIT",
                Empty 
                // absolute
                | ToTerm("cm")
                | ToTerm("mm")
                | ToTerm("Q")
                | ToTerm("in")
                | ToTerm("px")
                | ToTerm("pt")
                | ToTerm("pc")
                // relative 
                | ToTerm("em")
                | ToTerm("ex")
                | ToTerm("ch")
                | ToTerm("rem")
                | ToTerm("vw")
                | ToTerm("vh")
                | ToTerm("vmin")
                | ToTerm("vmax")
                // angles
                | ToTerm("deg")
                | ToTerm("grad")
                | ToTerm("rad")
                | ToTerm("turn")
                 // times
                 | ToTerm("s")
                 | ToTerm("ms")
                 // frequency
                 | ToTerm("Hz")
                 | ToTerm("kHz")
                 // resolution
                 | ToTerm("dpi")
                 | ToTerm("dpcm")
                 | ToTerm("dppx")
            );
            var VAR_SYMBOL = new NonTerminal("VAR_SYMBOL", ToTerm("$"));
            var AT_SYMBOL = new NonTerminal("AT_SYMBOL", ToTerm("@"));
            var DOT_IDENT = new NonTerminal("DOT_IDENT");
            var CDO = new NonTerminal("CDO", ToTerm("<!--"));
            var CDC = new NonTerminal("CDC", ToTerm("-->"));
            var DASHMATCH = new NonTerminal("dashmatch", ToTerm(@"|="));

            var PIXEL = new NonTerminal("PIXEL", ToTerm("px"));

            var CSS_UNIT_VALUE = new NonTerminal("CSS_UNIT_VALUE");
            //    //var DIMENSION = new NonTerminal("DIMENSION", num + ident);
            //   // var STRING = new NonTerminal("STRING", string1 | string2);
            //    //var HASH = new NonTerminal("HASH", ToTerm("#") + name);
            //    var URI = new NonTerminal("URI");           
            //    var UNICODE_RANGE = new NonTerminal("UNICODE-RANGE");
            //    //var FUNCTION = new NonTerminal("FUNCTION", ident + "(");


            var STATEMENT = new NonTerminal("STATEMENT");
            var STYLESHEET = new NonTerminal("STYLESHEET");

            var VAR_RULE = new NonTerminal("VAR_RULE");
            var VAR_PROPERTY = new NonTerminal("VAR_PROPERTY");
            var VAR_PROPERTY_DECLARATION = new NonTerminal("VAR_PROPERTY_DECLARATION");
            var VAR_DECLARATION_LIST = new NonTerminal("VAR_DECLARATION_LIST");
            var VAR_DECLARATION = new NonTerminal("VAR_DECLARATION");

            var BLOCK = new NonTerminal("BLOCK");
            var BLOCK_BODY = new NonTerminal("BLOCK_BODY");
            var BLOCK_IDENTIFIER = new NonTerminal("BLOCK_IDENTIFIER");
            var NESTED_IDENTIFIER = new NonTerminal("NESTED_IDENTIFIER");
            var BLOCK_IDENTIFIERS = new NonTerminal("BLOCK_IDENTIFIERS");
            var BLOCK_ITEMS = new NonTerminal("BLOCK_ITEMS");
            var BLOCK_ITEM = new NonTerminal("BLOCK_ITEM");
            var DECLARATION = new NonTerminal("DECLARATION");
            var PROPERTY = new NonTerminal("PROPERTY");
            var VALUE_ITEM_GROUP = new NonTerminal("VALUE_3");
            var VALUE = new NonTerminal("VALUE");
            var DECLARATION_VALUES = new NonTerminal("DECLARATION_VALUES");
            var VAR_REFERENCE = new NonTerminal("VAR_REFERENCE");

            var IMPORT_RULE = new NonTerminal("IMPORT_RULE");

            var FONT_GROUP = new NonTerminal("FONT_GROUP");
            var FONT_STYLE = new NonTerminal("FONT_STYLE");
            var FONT_VARIANT = new NonTerminal("FONT_VARIANT");
            var FONT_WEIGHT = new NonTerminal("FONT_WEIGHT");
            var FONT_SIZE = new NonTerminal("FONT_SIZE");
            var LINE_WEIGHT = new NonTerminal("LINE_WEIGHT");
            var FONT_FAMILY = new NonTerminal("FONT_FAMILY");
            var FONT_FAMILY_MEMBER = new NonTerminal("FONT_FAMILY_MEMBER");
            var UNIT_SIZE = new NonTerminal("UNIT_SIZE");

            var MIXIN_RULE = new NonTerminal("MIXIN_RULE");
            var MIXIN_FUNCTION = new NonTerminal("MIXIN_FUNCTION");
            var MIXIN_BODY = new NonTerminal("MIXIN_BODY");
            var MIXIN_ARGS_LIST = new NonTerminal("MIXIN_ARGS_LIST");
            var MIXIN_FUNC_ARGS = new NonTerminal("MIXIN_FUNC_ARGS");

            var INCLUDE_MIXIN = new NonTerminal("INCLUDE_MIXIN");
            var MIXIN_CALL = new NonTerminal("MIXIN_CALL");
            var MIXIN_CALL_ARGS = new NonTerminal("MIXIN_CALL_ARGS");
            var MIXIN_CALL_ARGS_LIST = new NonTerminal("MIXIN_CALL_ARGS");
            var STRING = new NonTerminal("STRING");

            var STATEMENTS = new NonTerminal("STATEMENTS");
            var FIRST_CHARSET = new NonTerminal("FIRST_CHARSET");
            var CHARSET_RULE = new NonTerminal("CHARSET_RULE");

            var CSS_IMPORT = new NonTerminal("CSS_IMPORT");
            var IMPORT_KEYWORD = new NonTerminal("IMPORT_KEYWORD");
            var CSS_IMPORT_LOCATION = new NonTerminal("CSS_IMPORT_LOCATION");
            var CSS_IMPORT_URL = new NonTerminal("CSS_IMPORT_URL");
            var SCSS_IMPORT = new NonTerminal("SCSS_IMPORT");
            var SCSS_IMPORT_MODULES = new NonTerminal("SCSS_IMPORT_MODULES");
            var MEDIA_QUERY_LIST_OPTIONAL = new NonTerminal("MEDIA_QUERY_LIST_OPTIONAL");
            var MEDIA_QUERY_LIST = new NonTerminal("MEDIA_QUERY_LIST");
            var MEDIA_QUERY = new NonTerminal("MEDIA_QUERY");
            var MEDIA_CONDITION = new NonTerminal("MEDIA_CONDITION");
            var MEDIA_TYPE_CONDITION = new NonTerminal("MEDIA_TYPE_CONDITION");

            var MEDIA_IN_PARENS = new NonTerminal("MEDIA_IN_PARENS");

            var MEDIA_AND = new NonTerminal("MEDIA_AND");
            var MEDIA_AND_RHS = new NonTerminal("MEDIA_AND_RHS");
            var MEDIA_AND_CLAUSE = new NonTerminal("MEDIA_AND_CLAUSE");

            var MEDIA_TYPE = new NonTerminal("MEDIA_TYPE");

            var MEDIA_OR = new NonTerminal("MEDIA_OR");
            var MEDIA_OR_RHS = new NonTerminal("MEDIA_OR_RHS");
            var MEDIA_OR_CLAUSE = new NonTerminal("MEDIA_OR_CLAUSE");

            var MEDIA_CONDITION_WITHOUT_OR_OPTIONAL = new NonTerminal("MEDIA_CONDITION_WITHOUT_OR_OPTIONAL");
            var MEDIA_CONDITION_WITHOUT_OR = new NonTerminal("MEDIA_CONDITION_WITHOUT_OR");

            var MEDIA_NOT = new NonTerminal("MEDIA_NOT");
            var MEDIA_FEATURE = new NonTerminal("MEDIA_FEATURE");
            var MEDIA_FEATURE_GROUP = new NonTerminal("MEDIA_FEATURE_GROUP");
            var GENERAL_ENCLOSED = new NonTerminal("GENERAL_ENCLOSED");

            var MF_PLAIN = new NonTerminal("MF_PLAIN");
            var MF_BOOLEAN = new NonTerminal("MF_BOOLEAN");
            var MF_RANGE = new NonTerminal("MF_RANGE");
            var MF_RANGE_0 = new NonTerminal("MF_RANGE_0");
            var MF_RANGE_1 = new NonTerminal("MF_RANGE_1");
            var MF_RANGE_2 = new NonTerminal("MF_RANGE_2");
            var MF_RANGE_2_COMPARE = new NonTerminal("MF_RANGE_2_COMPARE");
            var MF_RANGE_3 = new NonTerminal("MF_RANGE_3");
            var MF_RANGE_3_COMPARE = new NonTerminal("MF_RANGE_3_COMPARE");
            var MF_RANGE_COMPARE = new NonTerminal("MF_RANGE_COMPARE");
            var MF_VALUE = new NonTerminal("MF_VALUE");

            var MIXIN_PARAM_REPLACE = new NonTerminal("MIXIN_PARAM_REPLACE");

            //  var CALL_ARGUMENT = new NonTerminal("CALL_ARGUMENT");

            //    var var_declare_member = new NonTerminal("var_declare_member");
            //    var var_color = new NonTerminal("var_color");

            //    var value = new NonTerminal("value");
            //    var block = new NonTerminal("block");
            //    var any = new NonTerminal("any");
            //    var at_rule = new NonTerminal("at-rule");
            //    var any_star = new NonTerminal("any_star");
            //    var any_plus = new NonTerminal("any_plus");

            //    var unused = new NonTerminal("unused");

            //    var ruleset = new NonTerminal("ruleset");
            //    var selector = new NonTerminal("selector");
            //    var declaration = new NonTerminal("declaration");
            //    var property = new NonTerminal("property");

            //     var S_star = new NonTerminal("S_star");

            #endregion

            #region 3. BNF rules

            // WHITESPACE  
            //S_star.Rule = MakeStarRule(S_star, S);

            // var stylesheet_nonstar = CDO | CDC | statement;
            STYLESHEET.Rule = FIRST_CHARSET + STATEMENTS;

            STATEMENTS.Rule = MakeStarRule(STATEMENTS, STATEMENT);

            FIRST_CHARSET.Rule = Empty | CHARSET_RULE;

            CHARSET_RULE.Rule = charset + double_quotestr + semicolon;

        //    STATEMENT.Rule = VAR_RULE | BLOCK | IMPORT_RULE | MIXIN_RULE | CHARSET_RULE | INCLUDE_MIXIN;
            STATEMENT.Rule = VAR_RULE | BLOCK | IMPORT_RULE | MIXIN_RULE | CHARSET_RULE | INCLUDE_MIXIN;

            ////var_declaration
            ////var_declaration.Rule = var_property + S_star + var_separator + S_star;
            VAR_RULE.Rule = VAR_PROPERTY + colon + VAR_PROPERTY_DECLARATION + semicolon;
            VAR_PROPERTY.Rule = VAR_SYMBOL + dash_ident;
            VAR_PROPERTY_DECLARATION.Rule = VAR_DECLARATION_LIST | color_rgb;
            VAR_DECLARATION_LIST.Rule = MakePlusRule(VAR_DECLARATION_LIST, comma, VAR_DECLARATION);
            VAR_DECLARATION.Rule = dash_ident;

            //block       : '{' S* [ any | block | ATKEYWORD S* | ';' S* ]* '}' S*;
            BLOCK.Rule = BLOCK_IDENTIFIERS + BLOCK_BODY;
            BLOCK_BODY.Rule = left_brace + BLOCK_ITEMS + right_brace;
            BLOCK_IDENTIFIERS.Rule = MakePlusRule(BLOCK_IDENTIFIERS, comma, NESTED_IDENTIFIER);

            NESTED_IDENTIFIER.Rule = MakePlusRule(NESTED_IDENTIFIER, BLOCK_IDENTIFIER);
            BLOCK_IDENTIFIER.Rule = DOT_IDENT | AT_SYMBOL + DOT_IDENT | dash_ident | AT_SYMBOL + dash_ident;
            DOT_IDENT.Rule = "." + dash_ident;

            BLOCK_ITEMS.Rule = MakeStarRule(BLOCK_ITEMS, BLOCK_ITEM);
            BLOCK_ITEM.Rule = BLOCK | FONT_GROUP | DECLARATION | INCLUDE_MIXIN | IMPORT_RULE;

            //declaration : property S* ':' S* value;
            //
            DECLARATION.Rule = PROPERTY + colon + DECLARATION_VALUES;

            //property    : IDENT;
            //
            PROPERTY.Rule = dash_ident;

            DECLARATION_VALUES.Rule = BLOCK_BODY | VALUE + semicolon;
            
            //PERCENTAGE.Precedence = 1;

            VALUE.Rule = MakePlusRule(VALUE, VALUE_ITEM_GROUP);
            // VALUE_1.Precedence = 4;

            VALUE_ITEM_GROUP.Rule = MIXIN_CALL | percentage | VAR_REFERENCE | CSS_UNIT_VALUE | zero_terminal | color_rgb | dash_ident | "none" | "block" | "inline-block" | STRING;
            // VALUE.Precedence = 3;

            CSS_UNIT_VALUE.Rule = css_number + CSS_UNIT;
            //VALUE_2.Precedence = 1;

            VAR_REFERENCE.Rule = VAR_SYMBOL + dash_ident;

            STRING.Rule = single_quotestr | double_quotestr;

            // SCSS IMPORT RULE
            // + CSS IMPORT RULE + media query + url
            // + SCSS comma array relative using node module
            IMPORT_RULE.Rule = IMPORT_KEYWORD + CSS_IMPORT + semicolon | IMPORT_KEYWORD + SCSS_IMPORT + semicolon;
            IMPORT_KEYWORD.Rule = import;
            
            CSS_IMPORT.Rule = CSS_IMPORT_LOCATION + MEDIA_QUERY_LIST_OPTIONAL;

            SCSS_IMPORT.Rule = SCSS_IMPORT_MODULES;
            SCSS_IMPORT_MODULES.Rule = MakePlusRule(SCSS_IMPORT_MODULES, comma, STRING);


            MEDIA_QUERY_LIST_OPTIONAL.Rule = Empty | MEDIA_QUERY_LIST;
            CSS_IMPORT_LOCATION.Rule = STRING | url + left_round + CSS_IMPORT_URL + right_round;
            CSS_IMPORT_URL.Rule = STRING | dash_ident;
            MEDIA_QUERY_LIST.Rule = MakePlusRule(MEDIA_QUERY_LIST, comma, MEDIA_QUERY);

           // MEDIA_QUERY.Rule = MEDIA_CONDITION + MEDIA_TYPE + MEDIA_CONDITION_WITHOUT_OR_OPTIONAL;
            MEDIA_QUERY.Rule = MEDIA_CONDITION | MEDIA_TYPE_CONDITION + MEDIA_TYPE + MEDIA_CONDITION_WITHOUT_OR_OPTIONAL;
            MEDIA_TYPE_CONDITION.Rule = Empty | "not" | "only";
            MEDIA_CONDITION.Rule = "not" + MEDIA_IN_PARENS | MEDIA_AND | MEDIA_OR | MEDIA_IN_PARENS;
            MEDIA_TYPE.Rule = ToTerm("all") | ToTerm("print") | ToTerm("screen") | ToTerm("speech");

            MEDIA_CONDITION_WITHOUT_OR_OPTIONAL.Rule = Empty | "and" + MEDIA_CONDITION_WITHOUT_OR;
            MEDIA_CONDITION_WITHOUT_OR.Rule = MEDIA_NOT | MEDIA_AND | MEDIA_IN_PARENS;

            MEDIA_NOT.Rule = "not" + MEDIA_IN_PARENS;

            MEDIA_AND.Rule = MEDIA_IN_PARENS + MEDIA_AND_RHS;
            MEDIA_AND_RHS.Rule = MakePlusRule(MEDIA_AND_RHS, MEDIA_AND_CLAUSE);
            MEDIA_AND_CLAUSE.Rule = left_square_b + "and" + MEDIA_IN_PARENS + right_square_b;

            MEDIA_OR.Rule = MEDIA_IN_PARENS + MEDIA_OR_RHS;
            MEDIA_OR_RHS.Rule = MakePlusRule(MEDIA_OR_RHS, MEDIA_OR_CLAUSE);
            MEDIA_OR_CLAUSE.Rule = "or" + MEDIA_IN_PARENS;

            MEDIA_IN_PARENS.Rule = left_round + MEDIA_CONDITION + right_round | MEDIA_FEATURE | GENERAL_ENCLOSED;
            GENERAL_ENCLOSED.Rule = MIXIN_CALL | left_round + dash_ident + VALUE_ITEM_GROUP + right_round;

            MEDIA_FEATURE.Rule = left_round + MEDIA_FEATURE_GROUP + right_round;
            MEDIA_FEATURE_GROUP.Rule = MF_PLAIN | MF_BOOLEAN | MF_RANGE; 

            MF_PLAIN.Rule = dash_ident + colon + MF_VALUE;
            MF_VALUE.Rule = CSS_UNIT_VALUE | dash_ident; // | dimension | ratio;
            MF_BOOLEAN.Rule = dash_ident;

            MF_RANGE.Rule = MF_RANGE_0 | MF_RANGE_1 | MF_RANGE_2 | MF_RANGE_3;
            MF_RANGE_0.Rule = dash_ident + MF_RANGE_COMPARE + MF_VALUE;
            MF_RANGE_1.Rule = MF_VALUE + MF_RANGE_COMPARE + dash_ident;
            MF_RANGE_2.Rule = MF_VALUE + MF_RANGE_2_COMPARE + dash_ident + MF_RANGE_2_COMPARE + MF_VALUE;
            MF_RANGE_2_COMPARE.Rule = less_than | le_than;
            MF_RANGE_3.Rule = MF_VALUE + MF_RANGE_3_COMPARE + dash_ident + MF_RANGE_3_COMPARE + MF_VALUE;
            MF_RANGE_3_COMPARE.Rule = greater_than | ge_than;
            MF_RANGE_COMPARE.Rule = less_than | greater_than | ge_than | le_than;

            FONT_GROUP.Rule = font + colon + FONT_STYLE + FONT_VARIANT + FONT_WEIGHT + FONT_SIZE + FONT_FAMILY + semicolon;

            FONT_STYLE.Rule = Empty
                //   | "normal"
                | "italic"
                | "oblique";
            //| "initial"
            //| "inherit";

            FONT_VARIANT.Rule = Empty
                //   | "normal" 
                | "small-caps";
              //  | "initial"
             //   | "inherit";

            FONT_WEIGHT.Rule = Empty
                //| "normal"
                | "bold"
                | "bolder"
                | "lighter"
                //| "initial"
                //| "inherit"
                | "100"
                | "200"
                | "300"
                | "400"
                | "500"
                | "600"
                | "700"
                | "800"
                | "900";

            FONT_SIZE.Rule = UNIT_SIZE + forward_slash + LINE_WEIGHT | UNIT_SIZE;
            UNIT_SIZE.Rule = percentage | CSS_UNIT_VALUE;
            LINE_WEIGHT.Rule = UNIT_SIZE;           
       
            FONT_FAMILY.Rule = VAR_REFERENCE | MakePlusRule(FONT_FAMILY, comma, FONT_FAMILY_MEMBER);
            FONT_FAMILY_MEMBER.Rule = dash_ident | STRING | "sans-serif" | "serif" | "monospace" | "cursive" | "fantasy" | "caption" | "icon" | "menu" | "message-box" | "small-caption" | "status-bar";

            MIXIN_RULE.Rule = mixin + MIXIN_FUNCTION + MIXIN_BODY;
            MIXIN_FUNCTION.Rule = dash_ident + MIXIN_FUNC_ARGS;
            MIXIN_FUNC_ARGS.Rule = Empty | left_round + MIXIN_ARGS_LIST + right_round;
            MIXIN_ARGS_LIST.Rule = MakePlusRule(MIXIN_ARGS_LIST, comma, VAR_PROPERTY);
            MIXIN_BODY.Rule = BLOCK_BODY;

            MIXIN_PARAM_REPLACE.Rule = "#{" + VAR_PROPERTY + "}";

            INCLUDE_MIXIN.Rule = include + MIXIN_CALL + semicolon;
            MIXIN_CALL.Rule = dash_ident + MIXIN_CALL_ARGS;
            MIXIN_CALL_ARGS.Rule = Empty | left_round + MIXIN_CALL_ARGS_LIST + right_round;
            MIXIN_CALL_ARGS_LIST.Rule = MakeStarRule(MIXIN_CALL_ARGS_LIST, comma, VALUE_ITEM_GROUP);
           // CALL_ARGUMENT.Rule = MIXIN_CALL | CSS_UNIT_VALUE | percentage | VAR_REFERENCE | CSS_UNIT_VALUE | zero_terminal | color_rgb | ident | "none" | "block" | "inline-block";

            //var_color.Rule = color_rgb;
            //var_declare_members.Rule = MakePlusRule(var_declare_members, comma, var_declare_member);
            //var_declare_member.Rule = IDENT;
            /**
            URI.Rule = uri_0 | uri_1;

            UNICODE_RANGE.Rule = unicode_0
                                | unicode_1
                                | unicode_2
                                | unicode_3
                                | unicode_4
                                | unicode_5
                                | unicode_6
                                | unicode_7;
            //block       : '{' S* [ any | block | ATKEYWORD S* | ';' S* ]* '}' S*;
            //
            **
            var block_grp = any | block | ATKEYWORD + S_star | ";" + S_star;
            var block_grp_star = new NonTerminal("block_grp_star");
            block_grp_star.Rule = MakeStarRule(block_grp_star, block_grp);
            block.Rule = ToTerm("{") + S_star + block_grp_star + "}" + S_star;

            //at-rule     : ATKEYWORD S* any* [ block | ';' S* ];
            //
            var at_rule_grp = block | ";" + S_star;
            at_rule.Rule = ATKEYWORD + S_star + any_star + at_rule_grp;

            //value       : [ any | block | ATKEYWORD S* ]+;
            //
            var value_grp = any | block | ATKEYWORD + S_star;
            var value_grp_plus = new NonTerminal("value_grp_plus");
            value_grp_plus.Rule = MakePlusRule(value_grp_plus, value_grp);
            value.Rule = value_grp_plus;

            //any         : [ IDENT | NUMBER | PERCENTAGE | DIMENSION | STRING
            //                | DELIM | URI | HASH | UNICODE-RANGE | INCLUDES
            //                | DASHMATCH | ':' | FUNCTION S* [any|unused]* ')'
            //                | '(' S* [any|unused]* ')' | '[' S* [any|unused]* ']'
            //                ] S*; 
            
            var anyORunused = any | unused;
            var anyORunused_star = new NonTerminal("anyORunused_star");
            anyORunused_star.Rule = MakeStarRule(anyORunused_star, anyORunused);

            var any_grp = IDENT | NUMBER | PERCENTAGE | DIMENSION | STRING
                        | URI | HASH | UNICODE_RANGE | INCLUDES
                        | DASHMATCH | ":" | FUNCTION + S_star + anyORunused_star + ")"
                        | "(" + S_star + anyORunused_star + ")"
                        | "[" + S_star + anyORunused_star + "]"
                        ;

            any.Rule = any_grp + S_star;
            any_star.Rule = MakeStarRule(any_star, any);
            any_plus.Rule = MakePlusRule(any_plus, any);

            //unused      : block | ATKEYWORD S* | ';' S* | CDO S* | CDC S*;
            //
            unused.Rule = block | ATKEYWORD + S_star | ";" + S_star | CDO + S_star | CDC + S_star;

            //ruleset     : selector? '{' S* declaration? [ ';' S* declaration? ]* '}' S*;
            //
            var ruleset_grp = ToTerm(";") + S_star + declaration.Q();
            var ruleset_grp_star = new NonTerminal("ruleset_grp_star");
            ruleset_grp_star.Rule = MakeStarRule(ruleset_grp_star, ruleset_grp);
            ruleset.Rule = selector.Q() + "{" + S_star + declaration.Q() + ruleset_grp_star + "}" + S_star;

            //selector    : any+;
            //
            //var selector_plus = new NonTerminal("selector_plus");
            //selector_plus.Rule = MakePlusRule(selector_plus, selector);
            selector.Rule = any_plus;

            //declaration : property S* ':' S* value;
            //
            declaration.Rule = property + S_star + ":" + S_star + value;

            //property    : IDENT;
            //
            property.Rule = IDENT;
         **/
            #endregion

            MarkPunctuation(colon, semicolon, left_brace, right_brace, single_quote, left_round, right_round);
            MarkNotReported(import, IMPORT_KEYWORD, url, STRING);
            MarkTransient(VAR_SYMBOL, VAR_PROPERTY_DECLARATION, VAR_DECLARATION, VALUE_ITEM_GROUP, BLOCK_ITEM, PROPERTY, DECLARATION_VALUES, FIRST_CHARSET);
            MarkReservedWords("none", "block", "inline-block", "font", "@mixin" , "@import");

            //Set grammar root
            this.Root = STYLESHEET;
        }
    }
}
